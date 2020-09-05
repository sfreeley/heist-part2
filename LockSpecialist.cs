using System;

namespace Heist
{
    public class LockSpecialist : IRobber
    {

        public string Name { get; set; }
        public string Specialty { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public LockSpecialist(string name, int skill, int percentage)
        {
            Name = name;
            Specialty = "Lock Specialist (Cracks vault)";
            SkillLevel = skill;
            PercentageCut = percentage;
        }

        public void PerformSkill(Bank newBank)
        {
            newBank.VaultScore -= SkillLevel;
            Console.WriteLine($"{Name} is cracking the vault. Decreased security score by {SkillLevel} points.");
            if (newBank.VaultScore - SkillLevel <= 0)
            {
                Console.WriteLine($"{Name} has cracked the vaults!");

            }

        }
    }
}