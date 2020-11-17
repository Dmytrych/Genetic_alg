using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pcg;

namespace TA_Lab2._1
{
    static class GeneticCodeGenerator
    {
        private static int GenerateGeneIndex(int genCodeLength)
        {
            return new PcgRandom().Next(genCodeLength);
        }

        public static bool[] Next(GeneCollection basicGenes)
        {
            bool[] code = new bool[basicGenes.Genes.Length];

            int workingGeneIndex = GenerateGeneIndex(basicGenes.Genes.Length);
            code[workingGeneIndex] = true;

            return code;
        }
    }
}
