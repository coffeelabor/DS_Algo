using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain_Demo.Models.Sorting
{
    public class InsertionSort
    {

        public InsertionSort() { }

        public List<Transaction> InsertSort(List<Transaction> rawTrans)
        {
            int amountVal;
            for(int i = 1; i < rawTrans.Count; i++)
            {
                amountVal = rawTrans[i].Amount;
                for(int j = i-1; j >= 0;)
                {
                    if (amountVal < rawTrans[j].Amount)
                    {
                        rawTrans[j + 1] = rawTrans[j];
                        j--;
                        rawTrans[j + 1] = rawTrans[i];
                    }
                    else break;
                }
            }
            return rawTrans;
        }
    }
}
