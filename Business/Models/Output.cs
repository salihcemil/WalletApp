using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Output
    {
        /// <summary>
        /// Hash(Id) of related transaction (in bytes)
        /// </summary>
        public string OutputHash { get; set; }
        /// <summary>
        /// n. output of related transaction
        /// </summary>
        public int OutputIndex { get; set; }
        /// <summary>
        /// Output value of a transaction
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// The address of the recipient
        /// </summary>
        public string ScriptSignKey { get; set; }
    }
}
