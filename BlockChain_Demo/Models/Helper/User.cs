using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain_Demo.Models.Helper
{
    public class User
    {
        public string UserIDTxt { get; set; }
        public int UserIDInt { get; set; }
        public int PendingTransactions { get; set; }
        public ReactGraphProps Rgp { get; set; }
        public User(int userId)
        {
            UserIDTxt = string.Format("User_{0}", userId);
            UserIDInt = userId;
            Rgp = new ReactGraphProps(0, 500, userId);
        }
        public void increasePendingTransactions()
        {
            PendingTransactions++;
        }

        public void decreasePendingTransactions()
        {
            PendingTransactions--; //Todo Might be wrong
        }
    }
}
