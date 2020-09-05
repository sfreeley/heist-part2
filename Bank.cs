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

        public void PrintReconReport()
        {
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