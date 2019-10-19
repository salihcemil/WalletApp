using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Business.Models;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using System.Linq;

namespace MinerApp
{
    public partial class Form1 : Form
    {
        List<Transaction> incomingTransactions;
        List<Transaction> validTransactions;
        IHubProxy _hub;
        HubConnection connection;
        Block blk;
        DataTable incomingDt;
        DataTable validatedDt;
        public Form1()
        {
            InitializeComponent();
            incomingTransactions = new List<Transaction>();
            validTransactions = new List<Transaction>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectSync();
            while (connection.State != Microsoft.AspNet.SignalR.Client.ConnectionState.Connected) { }
            incomingDt = new DataTable();
            incomingDt.Columns.Add("SenderAddress");
            incomingDt.Columns.Add("ReceiverAddress");
            incomingDt.Columns.Add("Amount");
            datagrid_incomingTrx.DataSource = incomingDt;
            datagrid_incomingTrx.PerformLayout();
            validatedDt = new DataTable();
            validatedDt.Columns.Add("SenderAddress");
            validatedDt.Columns.Add("ReceiverAddress");
            validatedDt.Columns.Add("Amount");
            datagrid_validTrx.DataSource = validatedDt;
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void btn_validate_Click(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            validTransactions = validator.GetValidTransactions(incomingTransactions);

            foreach (var item in validTransactions)
            {
                if (incomingTransactions.Contains(item))
                {
                    incomingTransactions.Remove(item);
                }
            }
            updateValidGridview();
        }

        private void btn_mine_Click(object sender, EventArgs e)
        {
            if(validTransactions== null ||validTransactions.Count == 0)
            {
                MessageBox.Show("There is no new valid block");
            }

            DataAccess da = new DataAccess();
            Header latestHeader = new Header();
            latestHeader = da.getLatestBlockHeader();

            blk = new Block();
            blk = Business.Miner.CreateBlock(validTransactions, latestHeader);

            bool blockInserted = da.insertBlock(blk);

            bool outputListUpdated = da.updateOutputs(blk);

            if (blockInserted && outputListUpdated)
            {
                
            }
            else
            {
                MessageBox.Show("Error in creating block");
            }

        }

        private void btn_publishBlock_Click(object sender, EventArgs e)
        {
            publishBlock(blk);
        }

        private void publishBlock(Block blk)
        {
            ContainerMsg msg = new ContainerMsg
            {
                block = blk
            };
            string jsonStr = JsonConvert.SerializeObject(msg);
            _hub.Invoke("NewMessage", jsonStr);
        }

        #region SignalRConnections
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
            catch (Exception)
            {
                return;
            }
        }

        private void ProcessNewmessage(string msg)
        {
            ContainerMsg message = JsonConvert.DeserializeObject<ContainerMsg>(msg);
            if (message.transaction != null)
            {
                incomingTransactions.Add(message.transaction);
            }
            updateIncomingList();
        }

        private void updateIncomingList()
        {
            TransactionAbstract trxAbstract = new TransactionAbstract();
            trxAbstract = getTransactionAbstract(incomingTransactions[incomingTransactions.Count - 1]);

            List<TransactionAbstract> absList = new List<TransactionAbstract>();
            absList.Add(trxAbstract);
            incomingDt.Rows.Add(ToDataTable(absList).Rows[0].ItemArray);
            datagrid_incomingTrx.Refresh();
        }
        private void updateValidGridview()
        {
            
            //throw new NotImplementedException();
        }
        #endregion


        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public TransactionAbstract getTransactionAbstract(Transaction trx)
        {
            TransactionAbstract trxAbstract = new TransactionAbstract();
            List<Output> outputList = new List<Output>();
            DataAccess da = new DataAccess();
            Output outp = new Output();
            outp = da.getOutput(trx.Inputs[0].PrevTransactionHash, 0);
            trxAbstract.Amount = outp.Value;
            trxAbstract.ReceiverAddress = outp.ScriptSignKey;
            trxAbstract.SenderAddress = "noaddress";
            
            return trxAbstract;
        }
    }
   
}
