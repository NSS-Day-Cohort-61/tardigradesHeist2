using System;
using System.Collections.Generic;

namespace Heist_II
{
    class Program
    {
        static void Main(string[] args)
        {

            // List<string> specialties = new List<string>()
            // {
            //     "Lock Specialist",

            // }

            List<IRobber> rolodex = new List<IRobber>()
            {
                new LockSpecialist("Jeff", 88, 25),
                new LockSpecialist("Freynk", 78, 65),
                new Muscle("Karen", 55, 35),
                new Muscle("Butch", 23, 65),
                new Muscle("Douglas", 50, 43),
                new Hacker("Zuck", 99, 99)
            };
            Console.WriteLine($"Number of crew members: {rolodex.Count}");
            // Prompt user to enter name for new crew member
            string newCrewName = "";

            do
            {
                Console.Write($"Please enter name for new crew member: ");
                newCrewName = Console.ReadLine();

                if (newCrewName.Length > 0)
                {
                    Console.Write(@"Choose a specialty for this crew member:
                1. Lock Specialist
                2. Muscle
                3. Hacker
                : ");
                    int newCrewSpecialty = int.Parse(Console.ReadLine());

                    // once specialty has been entered prompt to enter crew members skill level as int between 1-100
                    Console.Write("Please enter crew member skill level from 1-100: ");
                    int newCrewSkillLevel = int.Parse(Console.ReadLine());

                    // then prompt user to enter percentage of cut for each mission
                    Console.Write("Please enter percentage of cut for each mission: ");
                    int newCrewPercentage = int.Parse(Console.ReadLine());

                    // once user entered all 3 make instance of appropriate class for that crew member and add to rolodex
                    switch (newCrewSpecialty)
                    {
                        case 1:
                            rolodex.Add(new LockSpecialist(newCrewName, newCrewSkillLevel, newCrewPercentage));
                            break;
                        case 2:
                            rolodex.Add(new Muscle(newCrewName, newCrewSkillLevel, newCrewPercentage));
                            break;
                        case 3:
                            rolodex.Add(new Hacker(newCrewName, newCrewSkillLevel, newCrewPercentage));
                            break;
                    }
                }
            }

            while
            (
                newCrewName.Length > 0
            );

        }
    }
}
