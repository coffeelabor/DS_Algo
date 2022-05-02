using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain_Demo.Models.Helper
{
    public class ReactGraphProps
    {
        private Random _rand = new Random();
        public int Fx { get; set; }
        public int Fy { get; set; }

        public int EdgeSource { get; set; }
        public int EdgeTarget { get; set; }

        public ReactGraphProps(int min, int max, int userId)
        {
            Fx = _rand.Next(min, max);
            Fy = _rand.Next(min, max);
            EdgeSource = userId;
        }
    }
}
