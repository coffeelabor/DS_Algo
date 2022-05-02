using BlockChain_Demo.Models.Helper;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain_Demo.Models
{
    public class Transaction
    {
        //public double Fee { get; set; }
        public string TransactionID { get; set; }
        public double Distance { get; set; }
        public int Amount { get; set; }
        public User Sender { get; set; } 
        public User Receiver { get; set; } //Receiver will be the node used for transaction
        public int BlockHeightEnter { get; set; } // Block Height when transaction was initialized
        public int BlockHeightProcessed { get; set; } // Block Heigth when Transaction was batched and mined
        public bool IsProcessed { get; set; }
        public string TimeOfTransaction { get; set; } // Date.now + ticks


        //public Transaction(User sender, User receiver, int amount, int feePriority)
        public Transaction(User sender, User receiver, string transTime, int amount, int blockHeight)
        {
            //TransactionID Sender Receiver Amount and TimeOfTransaction are core to the blockchain, rest are for app functioality
            TransactionID = getTransactionHash();
            Sender = sender;
            Receiver = receiver;
            Amount = amount;
            TimeOfTransaction = transTime;
            BlockHeightEnter = blockHeight;
            IsProcessed = false;
            //Fee = (feePriority / 100) * Amount;

        }
        //public double GetEdgeWeight()
        //{
        //    double sx = Sender.Rgp.Fx;
        //    double sy = Sender.Rgp.Fy;
        //    double rx = Receiver.Rgp.Fx;
        //    double ry = Receiver.Rgp.Fy;
        //    return Math.Sqrt(Math.Pow((sx - rx), 2) + Math.Pow((sy - ry), 2));
        //}
        public void setIsProcessed(int blockHeight)
        {
            BlockHeightProcessed = blockHeight;
            IsProcessed = true;
        }
        public int timeInMemPool()
        {
            // todo set based on blocks in memepool
            return 1;
        }

        public string getTransactionHash()
        {
            SHA256 sha256Object = SHA256.Create();
            // Convert all data to string to format for ASCII Encoding Result
            string transString = string.Format("{0}{1}{2}{3}", Sender, Receiver, Amount, TimeOfTransaction);
            // Convert to bytes since sha256 can only be passed byte[]
            byte[] transBytes = Encoding.ASCII.GetBytes(transString);
            // Use inherited ComputeHash method 
            byte[] transBytesResult = sha256Object.ComputeHash(transBytes);
            // Convert the hash result back to a string
            string transHashResult = Convert.ToBase64String(transBytesResult);

            return transHashResult;
        }
    }
}
