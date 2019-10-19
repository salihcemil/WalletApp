using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Business;

namespace WalletApp
{
    public static class Validator
    {
        public static bool validateBlock(Header latestHeader, Block newBlk, string starter)
        {
            if (newBlk.BlockHeader.Hash.Substring(0, newBlk.BlockHeader.DifficultyIndex) != starter)
            {
                return false;
            }
            if(newBlk.BlockHeader.PrevBlockHash != latestHeader.Hash)
            {
                return false;
            }
            if(Crypto.GetHash(Miner.GenerateMerkleRoot(newBlk.Transactions)+latestHeader.Hash + newBlk.BlockHeader.Time.ToString() + newBlk.BlockHeader.Nonce.ToString()) != newBlk.BlockHeader.Hash)
            {
                return false;
            }
            ;
            return true;
        }
    }
}
