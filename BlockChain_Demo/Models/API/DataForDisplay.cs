using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain_Demo.Models
{
    public class DataForDisplay
    {
        //private string _blockName = "Genisis Block";

        private Random _rand = new Random();
        public int index { get; set; }
        public int NumOfUsers { get; set; }
        public int BlockHeight { get; set; }
        public int MerklePath { get; set ; }
        public string BlockName { get;set; }

        //Graph config
        public int Fx { get; set; }
        public int Fy { get; set; }

        public int EdgeSource { get; set; }
        public int EdgeTarget { get; set; }

        public DataForDisplay() { }
        public int getRandom( int min = 0, int max = 100)
        {
            //int helperNum = _rand.Next(10);
            //if (helperNum % 2 == 0)
            //{
            //    return _rand.Next(min, max);
            //}
            return _rand.Next(min, max);
        }
    }
}
