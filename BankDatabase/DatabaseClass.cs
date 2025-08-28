using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDatabase
{
    public class DatabaseClass
    {
        private List<DataStruct> dataStructList;
        private DatabaseGenerator databaseGenerator;

        public DatabaseClass()
        {
            dataStructList = new List<DataStruct>();
            databaseGenerator = new DatabaseGenerator();

            for (int i = 0; i < 100; i++)
            {
                uint pin, acctNo;
                string firstName, lastName;
                int balance;

                databaseGenerator.GetNextAccount(out pin, out  acctNo, out firstName, out lastName, out balance);

                DataStruct dataStruct = new DataStruct()
                {
                    pin = pin,
                    acctNo = acctNo,
                    firstName = firstName,
                    lastName = lastName,
                    balance = balance
                };

                dataStructList.Add(dataStruct);
            }
        }

        public uint GetAcctNoByIndex(int index)
        {
            return dataStructList[index].acctNo;
        }

        public uint GetPINByIndex(int index)
        {
            return dataStructList[index].pin;
        }

        public string GetFirstNameByIndex(int index)
        {
            return dataStructList[index].firstName;
        }

        public string GetLastNameByIndex(int index)
        {
            return dataStructList[index].lastName;
        }

        public int GetBalanceByIndex(int index)
        {
            return dataStructList[index].balance;
        }

        public int getNumRecords()
        {
            return dataStructList.Count;
        }

    }
}
