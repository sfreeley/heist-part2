using System;

namespace Heist
{
    public interface IRobber
    {
        string Name { get; set; }
        string Specialty { get; set; }
        int SkillLevel { get; set; }
        int PercentageCut { get; set; }

        void PerformSkill(Bank newBank);

    }
}