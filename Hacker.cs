using System;

namespace Hesit_II
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank BankParam)
        {
            BankParam.AlarmScore -= SkillLevel;
            if (BankParam.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system!");
            }
            else
            {
                Console.WriteLine($"{Name} is hacking the alarm system. Decreased security {SkillLevel} points");
            }
        }
    }
}