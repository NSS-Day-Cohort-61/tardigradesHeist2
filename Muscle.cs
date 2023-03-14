using System;

namespace Heist_II
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public Muscle(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }

        public void PerformSkill(Bank BankParam)
        {
            BankParam.SecurityGuardScore -= SkillLevel;
            if (BankParam.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has beaten the hell out of the security!");
            }
            else
            {
                Console.WriteLine($"{Name} is giving security a swirly. Decreased security {SkillLevel} points");
            }
        }
    }
}