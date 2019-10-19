using Business.Models;
using System.Collections.Generic;
using System.Linq;

namespace MinerApp
{
    public class Validator
    {
        List<Output> allOutputs;
        DataAccess da;
        public Validator()
        {
            da = new DataAccess();
            allOutputs = da.getOutputList();
        }


        public List<Transaction> GetValidTransactions(List<Transaction> transactionList)
        {
            List<Transaction> validTransactions = new List<Transaction>();
            foreach (var item in transactionList)
            {
                if (ValidateTransaction(item))
                {
                    validTransactions.Add(item);
                }
            }
            return validTransactions;
        }

        private bool ValidateTransaction(Transaction trx)
        {
            if (trx.Inputs == null || trx.Outputs == null)
            {
                return false;
            }
            if (trx.VinSize != trx.Inputs.Count || trx.VoutSize != trx.Outputs.Count)
            {
                return false;
            }
            if (string.IsNullOrEmpty(trx.Hash))
            {
                return false;
            }
            if (!CheckOutputs(trx.Outputs))
            {
                return false;
            }
            if (!CheckInputs(trx.Inputs))
            {
                return false;
            }
            return true;
        }

        private bool CheckInputs(List<Input> inputs)
        {
            Output outp = new Output();

            foreach (var item in inputs)
            {
                if (!Business.Crypto.CheckSignature(item)) return false;
                outp = da.getOutput(item.PrevTransactionHash, item.OutputIndex);
                allOutputs.Remove(allOutputs.Where(t => t.OutputHash == outp.OutputHash && t.OutputIndex == t.OutputIndex).FirstOrDefault());
                if (allOutputs.Where(x => x.OutputHash == outp.OutputHash && x.OutputIndex == outp.OutputIndex).ToList().Count > 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckOutputs(List<Output> outputs)
        {
            foreach (var item in outputs)
            {
                if (string.IsNullOrEmpty(item.OutputHash) || string.IsNullOrEmpty(item.ScriptSignKey) || item.Value == 0) return false;
            }
            return true;
        }
    }
}
