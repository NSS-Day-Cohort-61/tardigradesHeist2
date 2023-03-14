using System;

namespace Hesit_II
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
         public LockSpecialist(string name, int skillLevel, int percentageCut) {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }

        public void PerformSkill(Bank BankParam)
        {
            BankParam.VaultScore -= SkillLevel;
            if (BankParam.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has broken into the vault!");
            }
            else
            {
                Console.WriteLine($"{Name} is drilling the vault. Decreased security {SkillLevel} points");
            }
        }
    }
}