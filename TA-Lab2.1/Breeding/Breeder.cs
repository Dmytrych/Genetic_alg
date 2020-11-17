using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TA_Lab2._1.Breeding
{
    class Breeder
    {
        public Generation CurrentGeneration { get; private set; }
        public BreedingSettings Settings { get; }

        public Breeder(Generation startGeneration, BreedingSettings settings)
        {
            CurrentGeneration = startGeneration;
            Settings = settings;
        }

        private GenerationMember Mutate(GenerationMember creature)
        {
            return new MutateAction(creature).Start();
        }

        private GenerationMember CrossBreed()
        {
            var bestCreature = CurrentGeneration.SelectBestMember();
            Thread.Sleep(20);
            var randomCreature = CurrentGeneration.SelectRandomMember();

            return new CrossBreedingAction(bestCreature, randomCreature).Start();
        }

        private GenerationMember Upgrade(GenerationMember child)
        {
            return new LocalUpgradeAction(child).Start();
        }

        private void SetMaxMember(GenerationMember member)
        {
            if (member.TotalCost > CurrentGeneration.MaxMember.TotalCost)
            {
                CurrentGeneration.MaxMember = member;
            }
        }
        public void Evolve()
        {
            var resultCreature = CrossBreed();
            var child = Mutate(resultCreature);
            var upgradedChild = Upgrade(child);

            if (upgradedChild.TotalWeight <= Settings.MaxBackpackCapacity)
            {
                CurrentGeneration.Members.Add(upgradedChild);
                SetMaxMember(upgradedChild);
                CurrentGeneration.DeleteWeakestMember();
            }
            else if (child.TotalWeight <= Settings.MaxBackpackCapacity)
            {
                CurrentGeneration.Members.Add(child);
                SetMaxMember(child);
                CurrentGeneration.DeleteWeakestMember();
            }

        }
    }
}
