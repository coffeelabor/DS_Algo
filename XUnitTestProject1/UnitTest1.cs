using BlockChain_Demo.Models;
using BlockChain_Demo.Models.Helper;
using System.Collections.Generic;
using Xunit;
namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestIsValid()
        {
            List<User> testUser = new List<User>();
            List<Transaction> testTransaction = new List<Transaction>();
            MiningPool testPool = new MiningPool();
            BlockChain testChain = new BlockChain();
            testUser.Add(new User(0));
            testUser.Add(new User(1));
            testTransaction.Add(new Transaction(testUser[1], testUser[0], "1234", 3, 1));
            testTransaction.Add(new Transaction(testUser[0], testUser[1], "1234", 2, 1));
            testChain.InsertNextBlock(testPool.GenerateBlock(testTransaction));
            testChain.InsertNextBlock(testPool.GenerateBlock(testTransaction));
            Assert.Equal(testChain.BlockChainList[2].PrevHash, testChain.BlockChainList[1].BlockHash);
        }
    }
}
