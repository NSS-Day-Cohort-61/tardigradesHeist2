using System;
using System.Collections.Generic;
using System.Linq;

namespace Heist_II
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
            Console.WriteLine($"Number of crew members: {rolodex.Count}");
            // Prompt user to enter name for new crew member
            string newCrewName = "";

            do
            {
                Console.Write($"Please enter name for new crew member: ");
                newCrewName = Console.ReadLine();

                if (newCrewName.Length > 0)
                {
                    int newCrewSpecialty;
                    while (true)
                    {
                        Console.Write(
                            @"Choose a specialty for this crew member:
        1. Lock Specialist
        2. Muscle
        3. Hacker
        : "
                        );
                        string specialtyInput = Console.ReadLine();
                        bool isNumber = int.TryParse(specialtyInput, out newCrewSpecialty);

                        if (isNumber && newCrewSpecialty >= 1 && newCrewSpecialty <= 3)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please choose 1, 2, or 3.");
                        }
                    }
                    int newCrewSkillLevel;
                    while (true)
                    {
                    Console.Write("Please enter crew member skill level from 1-100: ");
                    string levelInput = Console.ReadLine();
                    bool isNum = int.TryParse(levelInput, out newCrewSkillLevel); 
                    if (isNum == true && newCrewSkillLevel >= 1 && newCrewSkillLevel <= 100)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You blew it, enter a number between 1 and 100");
                    }
                    }

                    // then prompt user to enter percentage of cut for each mission
                    int newCrewPercentage = -1;
                    do 
                    {
                    Console.Write("Please enter percentage of cut for each mission: ");
                    string newCrewPercentageString = (Console.ReadLine());
                    int newnewnew;
                    bool isNum = int.TryParse(newCrewPercentageString, out newnewnew);
                    if (isNum && newnewnew >= 1 && newnewnew <= 100)
                    {
                        newCrewPercentage = newnewnew;
                    }
                    else
                    {
                        Console.WriteLine("....between 1 and 100....");
                    }
                    }
                    while (newCrewPercentage == -1);
                    


                    // once user entered all 3 make instance of appropriate class for that crew member and add to rolodex
                    switch (newCrewSpecialty)
                    {
                        case 1:
                            rolodex.Add(
                                new LockSpecialist(
                                    newCrewName,
                                    newCrewSkillLevel,
                                    newCrewPercentage
                                )
                            );
                            break;
                        case 2:
                            rolodex.Add(
                                new Muscle(newCrewName, newCrewSkillLevel, newCrewPercentage)
                            );
                            break;
                        case 3:
                            rolodex.Add(
                                new Hacker(newCrewName, newCrewSkillLevel, newCrewPercentage)
                            );
                            break;
                    }
                }
            } while (newCrewName.Length > 0);

            /*
                Let's do a little recon next. Print out a Recon Report to the user.
                This should tell the user what the bank's most secure system is, and what its least secure system is
                (don't print the actual integer scores--just the name, i.e. Most Secure: Alarm Least Secure: Vault
            */
            Bank bank = new Bank();
            Dictionary<string, int> bankProps = new Dictionary<string, int>();

            bankProps["Alarm"] = bank.AlarmScore;
            bankProps["Guards"] = bank.SecurityGuardScore;
            bankProps["Vault"] = bank.VaultScore;

            var sortedBankProps =
                from entry in bankProps
                orderby entry.Value ascending
                select entry;

            // rather than hardcode, get the first and last keys of the sorted the IOrderedEnumerable
            List<KeyValuePair<string, int>> sortedBankPropsList = sortedBankProps.ToList();
            Console.WriteLine();
            Console.WriteLine(" --- RECON REPORT --- ");
            Console.WriteLine($"Most secure: {sortedBankPropsList[0].Key}");
            Console.WriteLine(
                $"Least secure: {sortedBankPropsList[sortedBankPropsList.Count - 1].Key}"
            );

            List<IRobber> team = new List<IRobber>();
            string crewMemberSelection = "";
            int sumOfCuts = 0;

            do
            {
                // loop over the list of crew and display a report about each team member
                Console.WriteLine();
                Console.WriteLine(" --- ROLODEX --- ");

                int idx = 1;

                foreach (Robber crewMember in rolodex)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{idx}. {crewMember.Name}");
                    crewMember.DisplayCrewMemberReport();
                    idx++;
                }

                int crewMemberIndex;
                while (true)
                {
                    Console.WriteLine();
                    Console.Write($"Please enter the number of the operative you want to add: ");
                    crewMemberSelection = Console.ReadLine();

                    if (crewMemberSelection.Length > 0)
                    {
                        bool isNumber = int.TryParse(crewMemberSelection, out crewMemberIndex);

                        if (isNumber && crewMemberIndex >= 1 && crewMemberIndex <= rolodex.Count)
                        {
                            // this is in place of a .Pop method
                            team.Add(rolodex[crewMemberIndex - 1]);
                            sumOfCuts += rolodex[crewMemberIndex - 1].PercentageCut;
                            rolodex.RemoveAt(crewMemberIndex - 1);
                            rolodex = rolodex
                                .Where(crewMember => crewMember.PercentageCut + sumOfCuts <= 100)
                                .ToList();
                            break;
                        }
                        else
                            Console.WriteLine(
                                $"Please choose an operative # between 1 and {rolodex.Count}"
                            );
                    }
                }
            } while (crewMemberSelection.Length > 0 && rolodex.Count > 0);

            // run the heist
            Console.WriteLine();
            Console.WriteLine("Here we go...");
            Console.WriteLine();

            foreach (Robber teamMember in team)
            {
                teamMember.PerformSkill(bank);
            }

            Console.WriteLine();
            if (bank.IsSecure == false)
            {
                Console.WriteLine(" --- SUCCESS --- ");
                Console.WriteLine("Here's your payday:");
                foreach (Robber teamMember in team)
                {
                    Console.WriteLine(
                        $"{teamMember.Name}: ${bank.CashOnHand * teamMember.PercentageCut / 100}"
                    );
                }
            }
            else
            {
                Console.WriteLine(" --- BUSTED --- ");
                Console.WriteLine("What were you thinking?! I hope you have a great lawyer...");
            }
        }
    }
}
