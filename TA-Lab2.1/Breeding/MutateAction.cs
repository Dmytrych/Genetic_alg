using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pcg;

namespace TA_Lab2._1.Breeding
{
    class MutateAction : IBreedAction
    {
        private int _mutationChanceValue;
        private readonly GenerationMember _creature;

        public int MutationChance
        {
            get
            {
                return _mutationChanceValue;
            }
            set
            {
                if (value <= 100 && value >= 0)
                {
                    _mutationChanceValue = value;
                }
                else
                {
                    throw new Exception("Mutation chance must be from 0 to 100");
                }
            }
        }

        public MutateAction(GenerationMember creature)
        {
            _creature = creature;
            _mutationChanceValue = 99;
        }

        private GenerationMember Mutate()
        {
            bool[] resultGenCode = (bool[])_creature.GeneticCode.Clone();
            if (resultGenCode == null)
            {
                throw new NullReferenceException("Initial creature genetic code was null");
            }

            int mutatedGeneIndex = new PcgRandom().Next(resultGenCode.Length - 1);

            resultGenCode[mutatedGeneIndex] = true;

            return new GenerationMember(resultGenCode, _creature.GeneticCodeBase);
        }

        public GenerationMember Start()
        {
            GenerationMember resultCreature = _creature;
            int randomValue = new PcgRandom().Next(100);

            if (randomValue <= _mutationChanceValue)
            {
                resultCreature = Mutate();
            }

            return resultCreature;
        }
    }
}
