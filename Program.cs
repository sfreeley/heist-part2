using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {

            newBank.PrintReconReport();
            AskQuestions();
            ChooseYourCrew();
            PerformAllSkills();
            newBank.HeistSuccess();
            Loot();

        }

        static Bank newBank = new Bank();
        static List<IRobber> allRobbers = GetRobbers();
        static List<IRobber> crew = new List<IRobber>();
        static List<IRobber> GetRobbers()
        {
            Hacker gina = new Hacker("gina", 100, 30);
            Muscle greg = new Muscle("greg", 100, 20);
            LockSpecialist martin = new LockSpecialist("martin", 100, 20);
            Hacker sophie = new Hacker("sophie", 70, 10);
            Muscle paul = new Muscle("paul", 20, 20);
            //List of hackers, muscle, and lock specialists in interface type IRobber
            List<IRobber> rolodex = new List<IRobber>()
            {
                gina,
                greg,
                martin,
                sophie,
                paul
            };
            return rolodex;
        }

        static void AskQuestions()
        {

            while (true)
            {

                //count of number of operative in rolodex
                Console.WriteLine($"There are {allRobbers.Count} current operatives in the rolodex");

                //name of operative question
                Console.WriteLine("Type in the name of another operative you wish to add to your list of operatives");
                string operativeName = Console.ReadLine();
                if (operativeName == "")
                {

                    return;
                }

                //specialty question
                Console.WriteLine("Which specialty does your operative possess? Choose from the following list of specialities: \n 1. Hacker(Disables Alarms) \n 2. Muscle (Disarms guards) \n 3. Lock Specialist (cracks vault)");
                string specialtySelection = Console.ReadLine();

                //skill level question
                Console.WriteLine("What is your operative's skill level from 1 to 100?");
                string skillLevel = Console.ReadLine();

                //percentage cut question
                Console.WriteLine("How much of the cut will your operative demand?");
                string percentageOfCut = Console.ReadLine();

                switch (specialtySelection)
                {
                    case "1":
                        Hacker newHacker = new Hacker(operativeName, int.Parse(skillLevel), int.Parse(percentageOfCut));
                        allRobbers.Add(newHacker);
                        break;
                    case "2":
                        Muscle newMuscle = new Muscle(operativeName, int.Parse(skillLevel), int.Parse(percentageOfCut));
                        allRobbers.Add(newMuscle);
                        break;
                    case "3":
                        LockSpecialist newLockSpecialist = new LockSpecialist(operativeName, int.Parse(skillLevel), int.Parse(percentageOfCut));
                        allRobbers.Add(newLockSpecialist);
                        break;

                }

            }

        }

        static void ChooseYourCrew()
        {
            int percentageRemaining = 100;
            while (true)
            {
                int index = 1;
                Console.WriteLine("This is your current rolodex of operatives you can choose from:");

                foreach (IRobber robber in allRobbers)
                {
                    if (robber.PercentageCut > percentageRemaining)
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine(index++);
                        Console.WriteLine($"Operative Name: {robber.Name}");
                        Console.WriteLine($"Specialty: {robber.Specialty}");
                        Console.WriteLine($"Skill Level: {robber.SkillLevel}");
                        Console.WriteLine($"Percentage Cut: {robber.PercentageCut}");
                    }

                }

                Console.WriteLine("Choose the number of an operative you want to add to your team");
                string userIndexChoice = Console.ReadLine();

                if (userIndexChoice == "")
                {
                    return;
                }
                crew.Add(allRobbers[int.Parse(userIndexChoice) - 1]);
                percentageRemaining -= allRobbers[int.Parse(userIndexChoice) - 1].PercentageCut;
                Console.WriteLine(percentageRemaining);
                allRobbers.Remove(allRobbers[int.Parse(userIndexChoice) - 1]);
                Console.WriteLine("***These are your current crew members***:");

                foreach (IRobber member in crew)
                {
                    Console.WriteLine(member.Name);
                    Console.WriteLine(member.Specialty);
                    Console.WriteLine(member.SkillLevel);
                    Console.WriteLine(member.PercentageCut);
                    Console.WriteLine("---------------");

                }

            }

        }

        static void PerformAllSkills()
        {
            foreach (IRobber member in crew)
            {

                member.PerformSkill(newBank);
            }
        }

        // static void HeistSuccess()
        // {
        //     if (newBank.)
        //     {
        //         Console.WriteLine("Sorry you're going to jail!");
        //     }
        //     else
        //     {
        //         Console.WriteLine("We're rich, baby!");
        //     }

        // }

        static void Loot()
        {
            if (!newBank.IsSecure)
            {
                foreach (IRobber member in crew)
                {
                    Console.WriteLine($"You have {newBank.CashOnHand}");
                    int personalLoot = newBank.CashOnHand * (member.PercentageCut / 100);
                    Console.WriteLine($"{member.Name} gets {personalLoot}");
                    Console.WriteLine($"You take home {newBank.CashOnHand - personalLoot}");
                }
            }

        }

    }
}