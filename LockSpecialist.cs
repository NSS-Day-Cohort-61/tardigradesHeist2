using System;

namespace Heist_II
{
    public class LockSpecialist : Robber, IRobber
    {
        public LockSpecialist(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            Specialty = "Lock Specialist";
            PercentageCut = percentageCut;
        }

        public override void PerformSkill(Bank BankParam)
        {
            BankParam.VaultScore -= SkillLevel;
            if (BankParam.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has broken into the vault!");
            }
            else
            {
                Console.WriteLine(
                    $"{Name} is drilling the vault. Decreased security {SkillLevel} points"
                );
            }
        }
    }
}
