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

        public void PerformSkill(Bank newBank)
        {
            // newBank.AlarmScore - SkillLevel;
            Console.WriteLine($"{Name} is hacking the alarm system. Decreased security score by {SkillLevel} points.");
            if (newBank.AlarmScore - SkillLevel == 0)
            {
                Console.WriteLine($"{Name} has knocked out all the security guards.");
            }

        }

    }
}