using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    /// <summary>
    /// Mapping object between block and transaction
    /// </summary>
    public class Blk_trx
    {
        /// <summary>
        /// Id of related block
        /// </summary>
        public int BlockId { get; set; }
        /// <summary>
        /// Id of the transaction
        /// </summary>
        public string TransactionId { get; set; }
        /// <summary>
        /// Index of the transaction inside the block
        /// </summary>
        public int Index { get; set; }
    }
}
