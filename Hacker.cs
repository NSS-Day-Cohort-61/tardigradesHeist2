using System;

namespace Heist_II
{
    public class Hacker : Robber, IRobber
    {
        public Hacker(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            Specialty = "Hacker";
            PercentageCut = percentageCut;
        }

        public override void PerformSkill(Bank BankParam)
        {
            BankParam.AlarmScore -= SkillLevel;
            if (BankParam.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system!");
            }
            else
            {
                Console.WriteLine(
                    $"{Name} is hacking the alarm system. Decreased security {SkillLevel} points"
                );
            }
        }
    }
}
