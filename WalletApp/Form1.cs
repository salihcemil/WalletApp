using System;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;
using Business.Models;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR.Client;

namespace WalletApp
{
    public partial class Form1 : Form
    {
        public decimal balance;
        public string publicKey;
        public string privateKey;
        public List<Output> outputList;
        IHubProxy _hub;
        HubConnection connection;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            publicKey = ConfigurationManager.AppSettings["publicKey"];
            privateKey = ConfigurationManager.AppSettings["privateKey"];
            lbl_address.Text = publicKey;
            lbl_balance.Text = getBalance(publicKey).ToString();
            getBalance(publicKey);
            ConnectSync();
            while (connection.State != ConnectionState.Connected) { }
        }

        private List<Output> getOutputList(string publicKey)
        {
            DataAccess da = new DataAccess();
            outputList = da.getOutputListByAddress(publicKey);

            return outputList;
        }

        private decimal getBalance(string publicKey)
        {
            getOutputList(publicKey);

            if (outputList.Count > 0)
            {
                balance = outputList.Sum(x => x.Value);
                return balance;
            }
            else
            {
                return 0;
            }
        }
        
        #region button events
        private void btn_send_Click(object sender, EventArgs e)
        {
            Transaction trx = new Transaction();
            decimal amount = Convert.ToDecimal(tb_amount.Text);
            if (amount <= getBalance(publicKey))
            {
                trx = Business.Business.GenerateTransaction(tb_receiverAddress.Text, publicKey, privateKey, amount, outputList);
            }
            else
            {
                MessageBox.Show("Amount cannot be bigger than balance");
            }
            
            if(trx.Inputs != null)
            {
                sendTransaction(trx);
            }
        }
        private void sendTransaction(Transaction trx)
        {
            ContainerMsg msg = new ContainerMsg();
            msg.transaction = trx;
            connectAndSend(msg);
        }
        private void btn_refreshBalance_Click(object sender, EventArgs e)
        {
            lbl_balance.Text = getBalance(publicKey).ToString();
        }
        #endregion
        

        #region signalR Connection
        
        private void connectAndSend(ContainerMsg msg)
        {
            string jsonStr = JsonConvert.SerializeObject(msg);
            _hub.Invoke("NewMessage", jsonStr);
        }
        private void ConnectSync()
        {
            string url = "http://localhost:8080/";
            connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("ConnectorHub");
            _hub.On<string>("newMessageReceived", x => ProcessNewmessage(x));

            try
            {
                connection.Start();
            }
            catch (Exception )
            {
                return;
            }
        }

        private void ProcessNewmessage(string msg)
        {
            ContainerMsg message = JsonConvert.DeserializeObject<ContainerMsg>(msg);
            if(message.block != null)
            {
                DataAccess da = new DataAccess();
                if (validateBlock(message.block, da.getLatestBlockHeader()))
                {
                    da.insertBlock(message.block);
                    da.updateOutputs(message.block);
                }
            }
        }

        private bool validateBlock(Block newBlock, Header latestHeader)
        {
            string starter = string.Empty;
            for (int i = 0; i < newBlock.BlockHeader.DifficultyIndex; i++)
            {
                starter = starter + "0";
            }
            if (Validator.validateBlock(latestHeader, newBlock, starter)) return true;
            return false;
        }
        #endregion
    }
}
