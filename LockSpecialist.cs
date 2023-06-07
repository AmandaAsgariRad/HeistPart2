using System;

namespace Group_HeistPt2
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public LockSpecialist(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }
        public void PerformSkill(Bank bank)
        {
            //Reduce the bank's score of the vault
            bank.VaultScore -= this.SkillLevel;
            Console.WriteLine($"{this.Name} is cracking the safe. Decreased security by {this.SkillLevel} points.");
            //If the bank's score is less than or equal to 0, we have disabled the system.
            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{this.Name} has cracked the safe!");
            }
        }
    }
}