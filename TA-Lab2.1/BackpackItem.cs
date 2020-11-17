using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Lab2._1
{
    class BackpackItem
    {
        public int Weight { get; set; }
        public int Cost { get; set; }

        public BackpackItem(int weight, int cost)
        {
            Weight = weight;
            Cost = cost;
        }
    }
}
