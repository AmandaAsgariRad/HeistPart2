using System;
using System.Collections.Generic;
namespace Group_HeistPt2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize a rolodex of potential criminal partners
            List<IRobber> rolodex = new List<IRobber>{
                new Hacker("Amanda Asgari-Rad", 90, 45),
                new LockSpecialist("Nickolai Sheikov", 99, 20),
                new Hacker("Alex Bishop", 70, 20),
                new Hacker("Josh Barton", 99, 30),
                new Muscle("Courtney Gulledge", 99, 15),
                new Muscle("Lincoln Keesecker", 60, 5),
                new LockSpecialist("Nic Lahde", 75, 15),
                new LockSpecialist("Laura Furnivall", 50, 5),
                new Hacker("John Carmack", 100, 95)
            };

            //Boolean to check if we are still adding to the rolodex
            bool fullRolodex = false;

            Console.WriteLine($"{rolodex.Count} potential recruits in the rolodex.");

            //While we want to add to the rolodex
            while (!fullRolodex)
            {
                Console.WriteLine("NEW MEMBER");
                Console.WriteLine("-------------");
                Console.WriteLine("Enter new recruit's name:");
                //Take in input for user's name
                string name = Console.ReadLine();
                //If user's name is empty, break out of loop.
                if (name == "")
                {
                    fullRolodex = true;
                    break;
                }
                Console.WriteLine("Enter new recruit's specialty(1 - 3):");
                Console.WriteLine("1) Hacker");
                Console.WriteLine("2) Muscle");
                Console.WriteLine("3) Lock Specialist");
                //Parse the selected specialty
                int specialty = int.Parse(Console.ReadLine());
                Console.Write("Enter new recruit's skill level 1-100: ");
                //Parse the selected skill level
                int skillLevel = int.Parse(Console.ReadLine());
                Console.Write("Enter new recruit's percentage cut 0-100:");
                //Parse the selected percentage cut
                int percentageCut = int.Parse(Console.ReadLine());

                //Run through logic to create a new member based upon the selected specialty.
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

            //Initialize our bank
            Bank heistBank = new Bank();
            Random r = new Random();
            //Randomly generate our different scores for the bank.
            heistBank.AlarmScore = r.Next(0, 101);
            heistBank.VaultScore = r.Next(0, 101);
            heistBank.SecurityGuardScore = r.Next(0, 101);
            heistBank.CashOnHand = r.Next(50000, 1000001);

            //Run the bank's recon report method.
            heistBank.ReconReport();
            Console.WriteLine();

            //Initialize the list of crew members
            List<IRobber> crew = new List<IRobber>();

            //Build the crew in rolodex report, and return out our remaining cut.
            int myCut = rolodexReport(rolodex, crew);


            //For each of our robbers, perform their respective skill on the randomized bank.
            foreach (IRobber robber in crew)
            {
                robber.PerformSkill(heistBank);
            }

            //If the bank is NOT secure
            if (!heistBank.IsSecure)
            {
                //Wrtie that the heist was a success
                Console.WriteLine("------------------------");
                Console.WriteLine("The heist was a success!");
                Console.WriteLine("------------------------");
                //Print the cash value of the heist
                Console.WriteLine($"Total Take: ${heistBank.CashOnHand.ToString("0.00")}");
                Console.WriteLine();
                //For each member of our crew, calculate how much money they received.
                foreach (IRobber robber in crew)
                {
                    //The crew members take is equal to their percentage * the total cash
                    decimal crewMemberTake = Math.Round(heistBank.CashOnHand * (robber.PercentageCut / 100.0M), 2);
                    string crewTakeString = crewMemberTake.ToString("0.00");
                    Console.WriteLine($"{robber.Name} receives ${crewTakeString}");
                }
                //The remaining take after the crew members get their respective amounts.
                decimal myTake = Math.Round(heistBank.CashOnHand * (myCut / 100.0M), 2);
                string myTakeString = myTake.ToString("0.00");
                Console.WriteLine();
                Console.WriteLine($"My take is ${myTakeString}...");
            }
            else
            {
                //Tell them they FAILED!
                Console.WriteLine();
                Console.WriteLine("Was prison the goal? You failed the heist...");
            }


        }
        public static int rolodexReport(List<IRobber> rolodex, List<IRobber> crew)
        {
            //Initialize the person running the program's cut to 100%
            int myCut = 100;

            //While that cut is greater than 0, run the following.
            while (myCut > 0)
            {
                Console.WriteLine("ROLODEX REPORT");
                Console.WriteLine("-------------");

                //Loop through until we have listed every possible member.
                for (int i = 0; i < rolodex.Count; i++)
                {
                    //If the person's cut DOES NOT reduce our cut below 0, write out their information.
                    if (myCut - rolodex[i].PercentageCut >= 0)
                    {
                        Console.WriteLine($"Index: {i} | Name: {rolodex[i].Name} | Skill: {rolodex[i].GetType().Name} | Skill Level: {rolodex[i].SkillLevel} | Percentage Cut: {rolodex[i].PercentageCut}");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("ADD A MEMBER TO CREW");
                Console.WriteLine("Enter their index?: ");
                string selectedValue = Console.ReadLine();
                //If they enter nothing, break out of the loop.
                if (selectedValue == "")
                {
                    break;
                }
                //Parse the selected member
                int selectedMember = int.Parse(selectedValue);

                //Deduct the selected person's cut from the user's cut.
                myCut -= rolodex[selectedMember].PercentageCut;

                //Add the selected member to the crew
                crew.Add(rolodex[selectedMember]);
                //Remove the selected member from the rolodex.
                rolodex.Remove(rolodex[selectedMember]);
                Console.WriteLine($"{crew.Count} members recruited. {myCut} percent of the take is left for you.");
                Console.WriteLine();
            }
            //Return out the user's cut.
            return myCut;
        }
    }
}
