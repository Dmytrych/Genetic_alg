using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Lab2._1.Breeding
{
    class BreedingSettings
    {
        public int MaxBackpackCapacity { get; private set; }

        public BreedingSettings(int maxBackpackCapacity)
        {
            MaxBackpackCapacity = maxBackpackCapacity;
        }
    }
}
