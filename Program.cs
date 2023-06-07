using System;
using System.Collections.Generic;
namespace Group_HeistPt2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> rolodex = new List<IRobber>{
                new Hacker("Amanda Asgari-Rad", 90, 45),
                new LockSpecialist("Nickolai Sheikov", 75, 20),
                new Hacker("Alex Bishop", 70, 20),
                new Hacker("Josh Barton", 95, 30),
                new Muscle("Courtney Gulledge", 80, 15),
                new Muscle("Lincoln Keesecker", 60, 5),
                new LockSpecialist("Nic Lahde", 75, 15),
                new LockSpecialist("Laura Furnivall", 50, 5),
                new Hacker("John Carmack", 100, 95)
            };
            bool fullRolodex = false;

            Console.WriteLine($"{rolodex.Count} potential recruits in the rolodex.");
            while (!fullRolodex)
            {
                Console.WriteLine("NEW MEMBER");
                Console.WriteLine("-------------");
                Console.WriteLine("Enter new recruit's name:");
                string name = Console.ReadLine();
                if (name == "")
                {
                    fullRolodex = true;
                    break;
                }
                Console.WriteLine("Enter new recruit's specialty(1 - 3):");
                Console.WriteLine("1) Hacker");
                Console.WriteLine("2) Muscle");
                Console.WriteLine("3) Lock Specialist");
                int specialty = int.Parse(Console.ReadLine());
                Console.Write("Enter new recruit's skill level 1-100: ");
                int skillLevel = int.Parse(Console.ReadLine());
                Console.Write("Enter new recruit's percentage cut 0-100:");
                int percentageCut = int.Parse(Console.ReadLine());
                if (specialty == 1)
                {
                    rolodex.Add(new Hacker(name, skillLevel, percentageCut));
                }
                else if (specialty == 2)
                {
                    rolodex.Add(new Muscle(name, skillLevel, percentageCut));
                }
                else if (specialty == 3)
                {
                    rolodex.Add(new LockSpecialist(name, skillLevel, percentageCut));
                }
                else
                {
                    Console.WriteLine("Recruit creation failed. Try again with a 1, 2 or 3 as the specialty!!!!!!");
                }
                Console.WriteLine($"{rolodex.Count} potential recruits in the rolodex.");

            }

            Bank heistBank = new Bank();
            Random r = new Random();
            heistBank.AlarmScore = r.Next(0, 101);
            heistBank.VaultScore = r.Next(0, 101);
            heistBank.SecurityGuardScore = r.Next(0, 101);
            heistBank.CashOnHand = r.Next(50000, 1000001);

            heistBank.ReconReport();
            Console.WriteLine();
            rolodexReport(rolodex);

        }
        public static void rolodexReport(List<IRobber> rolodex)
        {
            Console.WriteLine("ROLODEX REPORT");
            Console.WriteLine("-------------");
            for (int i = 0; i < rolodex.Count; i++)
            {
                Console.WriteLine($"Index: {i} | Name: {rolodex[i].Name} | Skill: {rolodex[i].GetType().Name} | Skill Level: {rolodex[i].SkillLevel} | Percentage Cut: {rolodex[i].PercentageCut}");
            }
        }


    }
}
