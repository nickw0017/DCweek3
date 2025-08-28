using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class DatabaseGenerator
    {
        private Random rand;

        public DatabaseGenerator()
        {
            rand = new Random();
        }

        private string GetFirstname()
        {
            string[] firstNames = { "Joe", "Bob", "Karthus", "Greg", "Ethan", "Vog" };
            return firstNames[rand.Next(firstNames.Length)];
        }

        private string GetLastname()
        {
            string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Taylor", "Anderson" };
            return lastNames[rand.Next(lastNames.Length)];
        }

        private uint GetPIN()
        {
            return (uint)rand.Next(1000, 10000);
        }

        private uint GetAcctNo()
        {
            return (uint)rand.Next(10000000, 99999999);
        }

        private int GetBalance()
        {
            return rand.Next(0, 100000); 
        }

        public void GetNextAccount(out uint pin, out uint acctNo, out string firstName, out string lastName, out int balance)
        {
            pin = GetPIN();
            acctNo = GetAcctNo();
            firstName = GetFirstname();
            lastName = GetLastname();
            balance = GetBalance();
        }
    }
}
