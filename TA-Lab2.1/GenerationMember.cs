using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TA_Lab2._1
{
    class GenerationMember : IComparable
    {
        public GeneCollection GeneticCodeBase { get; }
        public bool[] GeneticCode { get; set; }
        public int TotalWeight { get; private set; }
        public int TotalCost { get; private set; }
        public int ActiveGenesCount { get; private set; }

        public GenerationMember(bool[] geneticCode, GeneCollection codeBase)
        {
            GeneticCode = geneticCode;
            GeneticCodeBase = codeBase;
            CountParams();
        }

        public void CountParams()
        {
            var weight = 0;
            var cost = 0;
            var activeGenesCount = 0;

            for (int i = 0; i < GeneticCode.Length; i++)
            {
                if (GeneticCode[i])
                {
                    var gene = GeneticCodeBase.Genes[i];
                    weight += gene.Weight;
                    cost += gene.Cost;
                    activeGenesCount++;
                }
            }

            ActiveGenesCount = activeGenesCount;
            TotalCost = cost;
            TotalWeight = weight;
        }

        public int CompareTo(object obj)
        {
            return this.TotalCost - ((GenerationMember) obj).TotalCost;
        }
    }
}
