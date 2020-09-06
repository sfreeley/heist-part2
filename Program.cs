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

        //instanstiating new classes and putting them in IRobber rolodex list
        static List<IRobber> GetRobbers()
        {
            Hacker gina = new Hacker("gina", 100, 60);
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
            //while true, keep asking user all the questions that adds an operative to the rolodex list
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

                //making sure user inputs a number between 1 and 100;
                while (int.Parse(skillLevel) < 1 || int.Parse(skillLevel) > 100)
                {
                    Console.WriteLine("What is your operative's skill level from 1 to 100?");
                    skillLevel = Console.ReadLine();

                }

                //percentage cut question
                Console.WriteLine("How much of the cut will your operative demand?");
                string percentageOfCut = Console.ReadLine();

                //based on user selection of which specialty( 1, 2, or 3), it will add that type of class into the rolodex
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
            //declaring the percentage of the cut remaining starting from 100%;
            int percentageRemaining = 100;

            //while true, keep asking user which index number for the operative they want to add
            while (true)
            {
                //declaring index number for the crew members
                int index = 1;
                Console.WriteLine("This is your current rolodex of operatives you can choose from:");

                //iterating through the rolodex list and...
                foreach (IRobber robber in allRobbers)
                {
                    //if the percentage of the cut remaining is zero, it will tell user the remaining cut is at zero and they cannot add anyone, will return and automatically run the heist
                    if (percentageRemaining == 0)
                    {
                        Console.WriteLine("***Percentage of cut remaining is now at zero. Automatically running the heist!***");
                        Console.WriteLine("---------------");
                        return;
                    }
                    //if the percentage cut is for any of the rolodex operative members is greater than the percentage cut remaining, they will show a message saying robber's name wants this percentage of cut, but you only have this percentage cut remaining
                    else if (robber.PercentageCut > percentageRemaining)
                    {
                        Console.WriteLine(index++);
                        Console.WriteLine($"Sorry {robber.Name} wants {robber.PercentageCut}% of the cut. \n Percentage of cut remaining for this heist is {percentageRemaining} \n ...Too much for this job!");
                    }
                    //else, if it doesn't meet any of the above criteria, will show the rolodex operative members and automatically change/increment the index number each time for each operative
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

                //if the user's choice on who to add is empty, return and heist is invoked;
                if (userIndexChoice == "")
                {
                    return;
                }

                //otherwise, add the crew member into the crew list;
                crew.Add(allRobbers[int.Parse(userIndexChoice) - 1]);
                //decrement percentage remaining based on that operative's percentage cut requested;
                percentageRemaining -= allRobbers[int.Parse(userIndexChoice) - 1].PercentageCut;
                //remove this member from the rolodex list so it doesn't show up on the rolodex list upon next iteration
                allRobbers.Remove(allRobbers[int.Parse(userIndexChoice) - 1]);
                Console.WriteLine("***These are your current crew members***:");

                //iterating through crew list to display current crew members on user's team
                foreach (IRobber member in crew)
                {
                    Console.WriteLine(member.Name);
                    Console.WriteLine($"Specialty: {member.Specialty}");
                    Console.WriteLine($"Skill Level: {member.SkillLevel}");
                    Console.WriteLine($"Percentage Cut: {member.PercentageCut}");
                    Console.WriteLine("---------------");

                }

            }

        }

        static void PerformAllSkills()
        {
            //iterate through crew members list and perform their designated skill on the bank;
            foreach (IRobber member in crew)
            {
                member.PerformSkill(newBank);
            }
        }

        static void Loot()
        {
            //declare total amount that has been dispersed to the crew members
            int totalDishedOut = 0;
            // if the bank is not secure (ie if crew was successful)
            if (!newBank.IsSecure)
            {
                //loop through the crew list and increment the amount dispersed to each person in the list (the returned integer amount calculated by TakeHomeMoney method on each individual class)
                foreach (IRobber member in crew)
                {
                    totalDishedOut += member.TakeHomeMoney(newBank);
                }
                //will subtract how much has been dispersed to the rest of the crew members from the total cash on hand, which will be user's remaining money
                int cashLeftForYou = newBank.CashOnHand - totalDishedOut;
                Console.WriteLine($"You get to keep: {cashLeftForYou}");
            }
        }
    }
}