using System;

namespace Heist_II
{
    public class Muscle : Robber, IRobber
    {
        public Muscle(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            Specialty = "Muscle";
            PercentageCut = percentageCut;
        }

        public override void PerformSkill(Bank BankParam)
        {
            BankParam.SecurityGuardScore -= SkillLevel;
            if (BankParam.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has beaten the hell out of the security!");
            }
            else
            {
                Console.WriteLine(
                    $"{Name} is giving security a swirly. Decreased security {SkillLevel} points"
                );
            }
        }
    }
}
