using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;

namespace Business
{
    public static class Miner
    {
        public static Block CreateBlock(List<Transaction> trxList, Header prevBlockHeader)
        {
            Block blk = new Block();

            blk.BlockHeader = GenerateHeader(trxList, prevBlockHeader);
            blk.BlockID = prevBlockHeader.ID + 1;
            blk.BlockHeader.ID = blk.BlockID;
            blk.Transactions = trxList;
            blk.TransactionsCount = trxList.Count;

            return blk;
        }

        private static Header GenerateHeader(List<Transaction> Transactions, Header prevBlockHeader)
        {
            Header header = new Header();

            header.DifficultyIndex = 5;
            header.HashMerkleRoot = GenerateMerkleRoot(Transactions);
            header.PrevBlockHash = prevBlockHeader.Hash;
            header.Time = DateTime.UtcNow;

            long nonce = 0;
            string starter = "1";
            string targetValue = "";
            for (int i = 0; i < header.DifficultyIndex; i++)
            {
                targetValue = targetValue + "0";
            }
            string hash;

            while (starter != targetValue)
            {
                hash = Crypto.GetHash(header.HashMerkleRoot + header.PrevBlockHash + header.Time.ToString() + nonce.ToString());
                starter = hash.Substring(0, header.DifficultyIndex);
                if (starter == targetValue)
                {
                    header.Hash = hash;
                    break;
                }
                nonce = nonce + 1;
            }

            header.Nonce = nonce;

            return header;
        }

        public static string GenerateMerkleRoot(List<Transaction> transactions)
        {
            List<string> strList = new List<string>();
            foreach (var item in transactions)
            {
                strList.Add(item.Hash);
            }
            if ((strList.Count % 2) == 0)
            {
                while (strList.Count > 1)
                {
                    strList.Add(Crypto.GetHash(strList[0] + strList[1]));
                    strList.RemoveAt(0);
                    strList.RemoveAt(0);
                }
            }
            else
            {
                while (strList.Count > 1)
                {
                    strList.Insert(strList.Count - 1, Crypto.GetHash(strList[0] + strList[1]));
                    if (strList.Count != 3) strList.RemoveRange(0, 2);
                    else
                    {
                        strList.RemoveAt(0);
                        strList.RemoveAt(1);
                    }
                }
            }
            return strList[0];
        }
    }
}
