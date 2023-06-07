using System;

namespace Group_HeistPt2
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public Muscle(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }
        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore -= this.SkillLevel;
            Console.WriteLine($"{this.Name} is fighting security guards. Decreased security presence by {this.SkillLevel} points.");
            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{this.Name} has permanently disabled the security guards!");
            }
        }
    }
}