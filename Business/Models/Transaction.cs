using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Transaction
    {
        /// <summary>
        /// Hash of the transaction (Also used as TrxId in inputs)
        /// </summary>
        public string Hash { get; set; }
        /// <summary>
        /// Count of the inputs which is contained in the InputList
        /// </summary>
        public int VinSize { get; set; }
        /// <summary>
        /// The list of inputs for the transaction
        /// </summary>
        public List<Input> Inputs { get; set; }
        /// <summary>
        /// Count of the outputs of the transaction
        /// </summary>
        public int VoutSize { get; set; }
        /// <summary>
        /// The list of outputs of the transaction
        /// </summary>
        public List<Output> Outputs { get; set; }
        /// <summary>
        /// The value corresponds that when the transaction runs 
        /// </summary>
        public DateTime LockTime { get; set; }
    }
}
