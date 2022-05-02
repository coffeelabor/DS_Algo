using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain_Demo.Models
{
    // Source: https://www.geeksforgeeks.org/blockchain-merkle-trees/
    // Source: https://medium.com/coinmonks/merkle-root-of-a-bitcoin-block-calculated-in-c-8c659a3b3290
    public class MerkleTree
    {
        //public string MerkleRootHash { get; set; }
        public MerkleTree() { }

        public string CreateMerkleRoot(IList<string> leafNodes)
        {

            if(leafNodes == null)
            {
                return "";
            }
            if(leafNodes.Count == 1)
            {
                return leafNodes.First();
            }
            if(leafNodes.Count() %2 != 0) // tree mush have even number of leaves
            {
                leafNodes.Add(leafNodes.Last());
            }

            List<string> treeBranch = new List<string>();
            SHA256 sha256Object = SHA256.Create();
            for (int i=0; i < leafNodes.Count(); i += 2)
            {
                string leafSet = string.Concat(leafNodes[i], leafNodes[i + 1]);
                byte[] leafBytes = Encoding.ASCII.GetBytes(leafSet);
                byte[] leafByteResult = sha256Object.ComputeHash(leafBytes);
                string leafHashResult = Convert.ToBase64String(leafByteResult);
                treeBranch.Add(leafHashResult);
            }
            return CreateMerkleRoot(treeBranch);
        }
    }
}
