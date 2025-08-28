using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using BankDatabase;

namespace BankServer
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    internal class DataServer : DataServerInterface
    {
        private readonly DatabaseClass db = new DatabaseClass();
        public int GetNumEntries() => db.getNumRecords();
        public void GetValuesForEntry(int index, out uint acctNo, out uint pin, out int bal, out string firstName, out string lastName)
        {
            if (index < 0 || index >= db.getNumRecords())
                throw new FaultException($"Index  {index} is out of range.");

            acctNo = db.GetAcctNoByIndex(index);
            pin = db.GetPINByIndex(index);
            bal = db.GetBalanceByIndex(index);
            firstName = db.GetFirstNameByIndex(index);
            lastName = db.GetLastNameByIndex(index);
        }
    }
}
