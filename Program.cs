using System;
using System.Collections.Generic;

namespace Hesit_II
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> rolodex = new List<IRobber>()
            {
                new LockSpecialist("Jeff", 88, 25),
                new LockSpecialist("Freynk", 78, 65),
                new Muscle("Karen", 55, 35),
                new Muscle("Butch", 23, 65),
                new Muscle("Douglas", 50, 43),
                new Hacker("Zuck", 99, 99)
            };
            Console.WriteLine($"{rolodex.Count}");
        // foreach(IRobber robber in rolodex)
        // {
        //     Console.WriteLine($"")
        // }
        }
    }
}
