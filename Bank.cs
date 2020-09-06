using System;

namespace Heist
{
    public class Bank
    {
        public int CashOnHand
        {
            get;
            set;
        }

        public int AlarmScore
        {
            get;
            set;
        }

        public int VaultScore
        {
            get;
            set;
        }

        public int SecurityGuardScore
        {
            get;
            set;
        }

        public bool IsSecure
        {
            get
            {
                if (AlarmScore <= 0 && VaultScore <= 0 && SecurityGuardScore <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public Bank()
        {
            AlarmScore = new Random().Next(0, 101);
            VaultScore = new Random().Next(0, 101);
            SecurityGuardScore = new Random().Next(0, 101);
            CashOnHand = new Random().Next(50000, 1000001);

        }

        //if the heist fails, display message to user, else display success message and how much money will be used to disperse each member's cut;
        public void HeistSuccess()
        {
            if (IsSecure)
            {
                Console.WriteLine("Sorry you're going to jail!");
            }
            else
            {
                Console.WriteLine("We're rich, baby!");
                Console.WriteLine($"Our loot: {CashOnHand}");
            }

        }

        //displays which areas of bank are most secure and least secure (based on randomly generated number)
        public void PrintReconReport()
        {
            //which area of bank is most secure;
            if (AlarmScore > VaultScore && AlarmScore > SecurityGuardScore)
            {
                Console.WriteLine($"Most Secure: Alarm");
            }
            else if (VaultScore > AlarmScore && VaultScore > SecurityGuardScore)
            {
                Console.WriteLine($"Most Secure: Vault");
            }
            else if (SecurityGuardScore > AlarmScore && SecurityGuardScore > VaultScore)
            {
                Console.WriteLine($"Most Secure: Security Guards");
            }

            //which are of bank is least secure;
            if (AlarmScore < VaultScore && AlarmScore < SecurityGuardScore)
            {
                Console.WriteLine($"Least Secure: Alarm");
            }
            else if (VaultScore < AlarmScore && VaultScore < SecurityGuardScore)
            {
                Console.WriteLine($"Least Secure: Vault");
            }
            else if (SecurityGuardScore < AlarmScore && SecurityGuardScore < VaultScore)
            {
                Console.WriteLine($"Least Secure: Security Guards");
            }

        }

    }
}