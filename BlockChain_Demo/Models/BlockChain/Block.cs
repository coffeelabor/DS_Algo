using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain_Demo.Models
{
    //Source: https://www.c-sharpcorner.com/article/blockchain-basics-building-a-blockchain-in-net-core/
    //Source: https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.sha256?view=net-5.0
    public class Block
    {
        public int BlockHeight {get;set;} // index that can be used as an ID
        public DateTime TimeStamp { get; set; } // Time of block creation
        public string PrevHash { get; set; } // hash of prev block
        public string BlockHash { get; set; } // hash of this block
        public string TransData { get; set; } // transactions 
        public int Nonce { get; set; }

        //public Block(DateTime timeStamp, string prevHash, string transData)
        public Block(DateTime timeStamp, string transData)
        {
            BlockHeight = 0;
            TimeStamp = timeStamp;
            //PrevHash = prevHash;
            TransData = transData;
            BlockHash = GetBlockHash();
        }

        public string GetBlockHash()
        {
            SHA256 sha256Object = SHA256.Create();
            // Convert all data to string to format for ASCII Encoding Result
            string blockString = string.Format("{0}{1}{2}{3}", BlockHeight, TimeStamp, PrevHash, TransData);
            // Convert to bytes since sha256 can only be passed byte[]
            byte[] blockBytes = Encoding.ASCII.GetBytes(blockString);
            // Use inherited ComputeHash method 
            byte[] blockBytesResult = sha256Object.ComputeHash(blockBytes);
            // Convert the hash result back to a string
            string blockHashResult = Convert.ToBase64String(blockBytesResult);

            return blockHashResult;
        }

    }
}
