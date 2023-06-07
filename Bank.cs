using System;

namespace Group_HeistPt2
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }

        public bool IsSecure
        {
            get
            {
                //return false if the system's are all disabled.
                return AlarmScore > 0 || VaultScore > 0 || SecurityGuardScore > 0;
            }
        }

        public void ReconReport()
        {

            Console.WriteLine("RECON REPORT");
            Console.WriteLine("-------------");

            //TEST CODE
            //Console.WriteLine($"test | alarm {this.AlarmScore} | vault {this.VaultScore} | guards {this.SecurityGuardScore} | money {this.CashOnHand}");

            if (this.AlarmScore > this.VaultScore && this.AlarmScore > this.SecurityGuardScore)
            {
                Console.WriteLine("Most Secure: Alarms");
                if (this.VaultScore > this.SecurityGuardScore)
                {
                    Console.WriteLine("Least Secure: Security Guards");
                }
                else
                {
                    Console.WriteLine("Least Secure: Vault");
                }
            }
            else if (this.VaultScore > this.SecurityGuardScore)
            {
                Console.WriteLine("Most Secure: Vault");
                if (this.SecurityGuardScore > this.AlarmScore)
                {
                    Console.WriteLine("Least Secure: Alarms");
                }
                else
                {
                    Console.WriteLine("Least Secure: Security Guards");
                }
            }
            else
            {
                Console.WriteLine("Most Secure: Security Guards");
                if (this.VaultScore > this.AlarmScore)
                {
                    Console.WriteLine("Least Secure: Alarms");
                }
                else
                {
                    Console.WriteLine("Least Secure: Vault");
                }
            }
        }

    }
}