using System;

namespace Heist_II
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }

        public Bank()
        {
            AlarmScore = new Random().Next(0, 101);
            VaultScore = new Random().Next(0, 101);
            SecurityGuardScore = new Random().Next(0, 101);
            CashOnHand = new Random().Next(50000, 1000000);
        }

        public bool IsSecure
        {
            get
            {
                if (CashOnHand > 0 || AlarmScore > 0 || VaultScore > 0 || SecurityGuardScore > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
