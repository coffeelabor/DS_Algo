using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using BlockChain_Demo.Models.Sorting;

namespace BlockChain_Demo.Models
{
    public class MiningPool
    {

        public int Nonce { get; set;}
        public string MerkleRootHash { get; set; }
        public Block BlockToMine { get; set; }
        public List<string> TransIds = new List<string>();

        public MerkleTree merkleTreeRoot;
        public InsertionSort sorting;
        //Stopwatch swMining;
        //private BlockHeader _headerDate;
        public MiningPool() // Treated As a Node.
        {

        }

        public Block GenerateBlock(IList<Transaction> pendingTrans)
        {
            merkleTreeRoot = new MerkleTree();
            sorting = new InsertionSort();
            getStringListID(pendingTrans);
            MerkleRootHash = merkleTreeRoot.CreateMerkleRoot(TransIds);
            BlockToMine = new Block(DateTime.Now, MerkleRootHash);
            //DemoChain.InsertNextBlock(newBlock);
            //BlockToMine.TransData = MerkleRootHash;
            BlockToMine.Nonce = mineBlock();
            
            return BlockToMine;
        }
        public void getMerklRootHash()
        {
            merkleTreeRoot = new MerkleTree();
        }
        public void getStringListID(IList<Transaction> pt)
        {
            foreach(Transaction t in pt)
            {
                TransIds.Add(t.TransactionID);

            }

        }
        public int mineBlock()
        {
            SHA256 sha256Object = SHA256.Create();
            string blockHashResult = "11";
            int nonce = -1;
            // Convert all data to string to format for ASCII Encoding Result
            while(blockHashResult.Substring(0,2) != "00")
            {
                nonce++; // increase the nonce until a hash with matching substring is created.
                string blockString = string.Format("{0}{1}{2}{3}{4}", BlockToMine.BlockHeight, BlockToMine.TimeStamp, BlockToMine.PrevHash, BlockToMine.TransData, nonce);
                // Convert to bytes since sha256 can only be passed byte[]
                byte[] blockBytes = Encoding.ASCII.GetBytes(blockString);
                // Use inherited ComputeHash method 
                byte[] blockBytesResult = sha256Object.ComputeHash(blockBytes);
                // Convert the hash result back to a string
                blockHashResult = Convert.ToBase64String(blockBytesResult);
            }
            return nonce;
            // if winning pool?
                // handle transaction.isProcessed = true
                // handle transaction.timeInMemPool(current block height)
                // only handle nodes that are receiver
                    // call decrementPendingTransactions.  if 0 return
        }
    }
}
