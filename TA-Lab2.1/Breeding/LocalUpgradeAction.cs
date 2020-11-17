using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pcg;

namespace TA_Lab2._1.Breeding
{
    class LocalUpgradeAction : IBreedAction
    {
        private readonly GenerationMember _member;

        public LocalUpgradeAction(GenerationMember member)
        {
            _member = member;
        }

        public GenerationMember Start()
        {
            bool[] genCode = (bool[]) _member.GeneticCode.Clone();

            for (int i = 1; i < new Random(0).Next(0, 40); i++)
            {
                genCode[new Random(i).Next(0, genCode.Length - 1)] = false;
            }

            for (int i = 1; i < new Random(0).Next(2, 20); i++)
            {
                genCode[new Random(i).Next(0, genCode.Length - 1)] = true;
            }

            var newCreature = new GenerationMember(genCode, _member.GeneticCodeBase);

            return newCreature;
        }
    }
}
