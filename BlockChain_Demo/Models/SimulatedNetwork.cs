using BlockChain_Demo.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain_Demo.Models
{
    public class SimulatedNetwork
    {
        public IList<User> SimUsers { get; set; }
        //public IList<Transaction> SimTrans { get; set; }
        public List<Transaction> SimTrans = new List<Transaction>();
        //public IList<string> TransIds { get; set; }
        public List<User> UsersWithPendingTrans = new List<User>();
        public Random rand = new Random();
        public MiningPool miningPool1 = new MiningPool();
        public BlockChain DemoChain;

        public SimulatedNetwork()
        {
            string userInput = "n";
            DemoChain = new BlockChain();
            SimUsers = new List<User>();
            for(int i = 0; i < 10; i++) //initialize with 10 users
            {
                SimUsers.Add(new User(i));
            }
            Console.WriteLine("Add new block? y or n ?");
            userInput = Console.ReadLine();
            
            while(userInput == "y")
            {
                GenerateMoreSimUsers(2);
                CreateSimTransactions(10);
                //miningPool1.GenerateBlock(SimTrans); //need root hash
                DemoChain.InsertNextBlock(miningPool1.GenerateBlock(SimTrans));
                Console.WriteLine("Add new block? y or n ?");
                userInput = Console.ReadLine();
            }

        }

        public void GenerateMoreSimUsers(int numToIncreaseBy)
        {
            int numUsers = SimUsers.Count;
            for(int i = numUsers-1; i < numToIncreaseBy; i++)
            {
                SimUsers.Add(new User(i));
            }
        }
        

        public void CreateSimTransactions(int numOfTransToCreate)
        {
            DateTime currentTime = DateTime.Now;
            DateTime timePassed;
            long timeDifference;
            int userSize = SimUsers.Count;
            int sender;
            User uSender;
            int receiver;
            User uReceiver;
            for(int i = 0; i < numOfTransToCreate; i++)
            {
                sender = rand.Next(0, userSize - 1);
                if (sender == 0) // Issue with frontend graph not liking when nodes source == target
                {
                    receiver = rand.Next(1, userSize - 1);
                }
                else
                {
                    if (rand.Next(0, 2) == 1)
                    {
                        receiver = rand.Next(0, sender);
                    }
                    else
                    {
                        receiver = rand.Next(sender + 1, userSize - 1);
                    }
                }
                timePassed = DateTime.Now;
                timeDifference = currentTime.Ticks - timePassed.Ticks;

                uSender = SimUsers[sender];
                uReceiver = SimUsers[receiver];
                //Transaction newTransaction = new Transaction(uSender, uReceiver, string.Format("{0}{1}", timePassed, timeDifference), rand.Next(0, 100), (DemoChain.Size-1));
                SimTrans.Add(new Transaction(uSender, uReceiver, string.Format("{0}{1}", timePassed, timeDifference), rand.Next(0, 100), (DemoChain.Size - 1)));
                UsersWithPendingTrans.Add(uSender); // list of user objects with transactions attached
            }
        }
        public string DisplaySimNetworkInfo()
        {
            string simNetString;
            string simUserString = "USERS:\n";
            string simBlockString = "BLOCKS:\n";
            //BlockChain helperChain = DemoChain;
            foreach(User user in SimUsers)
            { 
                simUserString = simUserString + string.Format
                    (
                        "\tUser Label: {0},\tUser ID: {1},\tFx: {2}\tFy: {3}\n",
                        user.UserIDTxt, user.UserIDInt, user.Rgp.Fx, user.Rgp.Fy
                    );
            }
            foreach(Block block in DemoChain.BlockChainList)
            {
                simBlockString = simBlockString + string.Format
                    (
                        "\tBlock Height: {0},\n\tTimeStamp: {1},\n\tPreveHash: {2}\n\tBlockHash: {3}\n\t, TranactionData: {4}\n",
                        block.BlockHeight, block.TimeStamp, block.PrevHash, block.BlockHash, block.TransData
                        
                    );
            }

            simNetString = simBlockString + simUserString;
            return simNetString;
        }

        public string GetSimTransactionTesting() // Todo only temp string
        {
            string simTransString;
            int userSize = SimUsers.Count;
            int sender = rand.Next(0, userSize - 1);
            int receiver;
            if (sender == 0) // Issue with frontend graph not liking when nodes source == target
            {
                receiver = rand.Next(1, userSize - 1);
            }
            else
            {
                if (rand.Next(0, 2) == 1)
                {
                    receiver = rand.Next(0, sender);
                }
                else
                {
                    receiver = rand.Next(sender + 1, userSize - 1);
                }
            }

            simTransString = string.Format("sender: {0}, reciever: {1}, Amount {2}",
                    sender, receiver, rand.Next(0, 100));

            return simTransString;
        }
        public void GenerateMoreBlocksTesting(int blocksToAdd)
        {
            Block newBlock;
            //for (int i = 0; i < blocksToAdd; i++)
            //{
            //    newBlock = new Block(DateTime.Now, GetSimTransaction());
            //    DemoChain.InsertNextBlock(newBlock);
            //}
        }
    }
}
