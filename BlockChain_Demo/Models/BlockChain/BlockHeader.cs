using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain_Demo.Models
{
    // Source https://developer.bitcoin.org/devguide/
    public class BlockHeader
    {
        private int _version = 1; // ProjReport: used if there are major updates (hard forks) to code 
        private string _prevBlockHash;
        private string _merkleRootHash; // Todo: replace with merkleRootObejct
        private DateTime _time;
        private int _nBits; // Todo find out what this is https://developer.bitcoin.org/reference/block_chain.html 
        private int _nonce;
        public BlockHeader()
        {

        }
    }
}
