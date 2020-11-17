using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TA_Lab2._1.Breeding
{
    class CrossBreedingAction : IBreedAction
    {
        private readonly GenerationMember _member1;
        private readonly GenerationMember _member2;

        public CrossBreedingAction(GenerationMember creature1, GenerationMember creature2)
        {
            _member1 = creature1;
            _member2 = creature2;
        }

        public GenerationMember Start()
        {
            bool[] childGeneticCode1 = new bool[_member1.GeneticCode.Length];
            bool[] childGeneticCode2 = new bool[_member1.GeneticCode.Length];


            for (int i = 0; i < childGeneticCode1.Length / 2; i++)
            {
                childGeneticCode1[i] = _member1.GeneticCode[i];
                childGeneticCode2[i] = _member2.GeneticCode[i];
            }

            for (int i = childGeneticCode1.Length / 2; i < childGeneticCode1.Length; i++)
            {
                childGeneticCode1[i] = _member2.GeneticCode[i];
                childGeneticCode2[i] = _member1.GeneticCode[i];
            }

            var child1 = new GenerationMember(childGeneticCode1, _member1.GeneticCodeBase);
            var child2 = new GenerationMember(childGeneticCode2, _member1.GeneticCodeBase);
            return child1.TotalCost > child2.TotalCost ? child1 : child2;
        }
    }
}
