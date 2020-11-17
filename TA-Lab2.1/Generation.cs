using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pcg;

namespace TA_Lab2._1
{
    class Generation
    {
        public List<GenerationMember> Members { get; set; }
        public GenerationMember MaxMember { get; set; }

        public Generation(GenerationMember[] members)
        {
            Members = new List<GenerationMember>(members);
            MaxMember = SelectBestMember();
        }

        public GenerationMember SelectBestMember()
        {
            return Members.Max();
        }

        public GenerationMember SelectRandomMember()
        {
            var randomIndex = new PcgRandom().Next(0, Members.Count - 1);
            return Members[randomIndex];
        }

        public override string ToString()
        {
            string reply = "\nGeneration state:\n" +
                           "Generation Quantity: " + Members.Count + "\n";
            var bestMember = MaxMember;
            reply += "Best member:\n" +
                     "--Cost: " + bestMember.TotalCost + "\n" +
                     "--Weight: " + bestMember.TotalWeight + "\n" +
                     "--Active genes: " + bestMember.ActiveGenesCount + "\n";
            return reply;
        }

        public void DeleteWeakestMember()
        {
            Members.Remove(Members.Min());
        }

        public void DepopulateTo(int creaturesToLeave)
        {
            if (Members.Count > creaturesToLeave)
            {
                Members.Sort();
                Members.RemoveRange(creaturesToLeave, Members.Count - creaturesToLeave - 1);
            }
        }
    }
}
