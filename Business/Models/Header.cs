using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Header
    {
        /// <summary>
        /// Id of owner block
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Hash of the block
        /// </summary>
        public string Hash { get; set; }
        /// <summary>
        /// The hash of prevous block
        /// </summary>
        public string PrevBlockHash { get; set; }
        /// <summary>
        /// Hash Merkle Root of all transactions' 
        /// hashes in the block
        /// </summary>
        public string HashMerkleRoot { get; set; }
        /// <summary>
        /// Time info
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// The count of starting zeros for PoW
        /// </summary>
        public int DifficultyIndex { get; set; }
        /// <summary>
        /// The Value yield to PoW solution
        /// </summary>
        public long Nonce { get; set; }
    }
}
