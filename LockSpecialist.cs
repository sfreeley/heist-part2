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

        public int TakeHomeMoney(Bank newBank)
        {
            int moneyToTake = newBank.CashOnHand * PercentageCut / 100;
            Console.WriteLine($"{Name} takes home: {moneyToTake}");
            return moneyToTake;

        }

        public void PerformSkill(Bank newBank)
        {
            newBank.VaultScore -= SkillLevel;
            Console.WriteLine($"{Name} is cracking the vault. Decreased security score by {SkillLevel} points.");
            if (newBank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has cracked the vaults!");

            }

        }
    }
}