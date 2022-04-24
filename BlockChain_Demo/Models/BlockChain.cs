using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain_Demo.Models
{
    public class BlockChain
    {
        private int _transactionId = -1;

        public BlockChain() { }

        public int getNextTransID()
        {
            _transactionId++;
            return _transactionId;
        }
    }
}
