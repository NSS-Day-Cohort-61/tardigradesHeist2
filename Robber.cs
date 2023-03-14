using System;

namespace Heist_II
{
    public class Robber : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public string Specialty { get; set; }

        public virtual void PerformSkill(Bank BankParam) { }

        public void DisplayCrewMemberReport()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Specialty: {Specialty}");
            Console.WriteLine($"Skill Level: {SkillLevel}");
            Console.WriteLine($"Cut: {PercentageCut}%");
        }
    }
}
