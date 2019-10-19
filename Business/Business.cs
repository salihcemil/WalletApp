using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Newtonsoft.Json;

namespace Business
{
    public static class Business
    {
        public static Transaction GenerateTransaction(string receiverAddress, string senderAddress, string senderPrivateKey, decimal amount, List<Output> outputList)
        {
            Transaction trx = new Transaction();
            trx.LockTime = DateTime.UtcNow;
            trx.Inputs = new List<Input>();
            trx.Outputs = new List<Output>();
            Input inp;

            foreach (var item in outputList)
            {
                inp = new Input
                {
                    OutputIndex = item.OutputIndex,
                    PrevTransactionHash = item.OutputHash,
                    ScriptSign = Crypto.getSignature(item.OutputHash + " " + item.OutputIndex, senderAddress, senderPrivateKey) + " " + senderAddress,
                };
                trx.Inputs.Add(inp);
            }
            
            if(outputList.Sum(x=>x.Value) == amount) //Only one output needed
            {
                Output out1 = new Output
                {
                    OutputIndex = 0,
                    ScriptSignKey = receiverAddress,
                    Value = 1000000
                };
                trx.Outputs.Add(out1);
            }
            else if(outputList.Sum(x => x.Value) > amount) //two outputs needed, one to receiver one back to sender
            {
                Output out1 = new Output
                {
                    OutputIndex = 0,
                    ScriptSignKey = receiverAddress,
                    Value = amount
                };
                Output out2 = new Output
                {
                    OutputIndex = 1,
                    ScriptSignKey = senderAddress,
                    Value = outputList.Sum(x => x.Value) - amount
                };
                trx.Outputs.Add(out1);
                trx.Outputs.Add(out2);
            }
            else
            {
                throw new NotImplementedException();
            }
           
            trx.VinSize = trx.Inputs.Count;
            trx.VoutSize = trx.Outputs.Count;
            trx.Hash = Crypto.GetHash(JsonConvert.SerializeObject(trx));
            foreach (var item in trx.Outputs)
            {
                item.OutputHash = trx.Hash;
            }

            return trx;
        }
    }
}
