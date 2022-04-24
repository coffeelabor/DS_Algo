using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain_Demo.Models
{
    public class Transaction
    {
        private double _amount;
        private double _fee;
        private string _sender; // Todo convert to user Object
        private string _receiver; // Todo convert to user Object
        private DateTime _timeOfTransaction;

        public Transaction() { }

        public bool isSender(bool initiatedTransaction) //Todo probably dont need this
        {
            return initiatedTransaction;
        }

        public void brodcastTransaction() { }

        public int timeInMemPool()
        {
            // todo get time.now - transTime in sec
            return 1;
        }
    }
}
