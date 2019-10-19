using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Block
    {
        /// <summary>
        /// The size of the block in bytes, some uses it as
        /// block number auto increments
        /// </summary>
        public int BlockID { get; set; }
        /// <summary>
        /// The header of block, contains identific infos 
        /// of block
        /// </summary>
        public Header BlockHeader { get; set; }
        /// <summary>
        /// Count of transaction list
        /// </summary>
        public int TransactionsCount { get; set; }
        /// <summary>
        /// List of transactions contained in the block
        /// </summary>
        public List<Transaction> Transactions { get; set; }
    }
}
