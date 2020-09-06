using System;

namespace Heist
{
    public class Muscle : IRobber
    {

        public string Name { get; set; }

        public string Specialty { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public Muscle(string name, int skill, int percentage)
        {
            Name = name;
            Specialty = "Muscle (Disarms guards)";
            SkillLevel = skill;
            PercentageCut = percentage;
        }

        //calculating the amount of money each member will receive from heist if heist is successful
        public int TakeHomeMoney(Bank newBank)
        {
            int moneyToTake = (newBank.CashOnHand * PercentageCut / 100);
            Console.WriteLine($"{Name} takes home: {moneyToTake}");
            Console.WriteLine("---------------");
            return moneyToTake;
        }
        public void PerformSkill(Bank newBank)
        {
            newBank.SecurityGuardScore -= SkillLevel;
            Console.WriteLine($"{Name} is taking care of the security guards. Decreased security score by {SkillLevel} points.");
            Console.WriteLine("---------------");
            if (newBank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has knocked out all the security guards.");

            }

        }

    }
}