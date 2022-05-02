using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain_Demo.Models
{
    //Source: https://www.c-sharpcorner.com/article/blockchain-basics-building-a-blockchain-in-net-core/
    public class BlockChain
    {
        public IList<Block> BlockChainList { get; set; }
        public int Size { get => BlockChainList.Count; }
        public BlockChain()
        {
            GenerateBlockChain();
            InsertGenesisBlock();
        }

        public void GenerateBlockChain()
        {
            BlockChainList = new List<Block>();
        }
        // First Block of a BlockChain has to be a Specially Configured Block called a 'GenesisBlock'
        public Block GenerateGenesisBlock()
        {
            //first block has no prev hash or transaction data
            return new Block(DateTime.Now, "{}"); 
        }
        public void InsertGenesisBlock()
        {
            BlockChainList.Add(GenerateGenesisBlock());
        }

        public Block GetPrevBlock()
        {
            return BlockChainList[Size - 1];
        }

        public void InsertNextBlock(Block newBlock)
        {
            Block prevBlock = GetPrevBlock();
            newBlock.BlockHeight = prevBlock.BlockHeight + 1;
            newBlock.PrevHash = prevBlock.BlockHash;
            newBlock.BlockHash = newBlock.GetBlockHash();
            BlockChainList.Add(newBlock);
        }

    }
}
