using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Input
    {
        /// <summary>
        /// Hash(Id) of related transaction (in bytes)
        /// </summary>
        public string PrevTransactionHash { get; set; }

        /// <summary>
        /// n. output of related transaction
        /// </summary>
        public int OutputIndex { get; set; }

        /// <summary>
        /// Signature + space + public key of sender
        /// </summary>
        public string ScriptSign { get; set; }

    }
}
