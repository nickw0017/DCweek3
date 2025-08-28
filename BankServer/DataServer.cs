using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using BankDatabase;
using SharedContracts;

namespace BankServer
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    internal class DataServer : DataServerInterface
    {
        private readonly DatabaseClass db = new DatabaseClass();
        public int GetNumEntries()
        {
            try
            {
                return db.getNumRecords();
            }
            catch (Exception ex)
            {
                throw new FaultException<ServiceFault>(
                    new ServiceFault { Code = "DB_ERROR", Message = ex.Message },
                    new FaultReason("Failed to read number of records"));
            }
        }


        public void GetValuesForEntry(int index, out uint acctNo, out uint pin, out int bal, out string firstName, out string lastName)
        {
            try
            {
                if (index < 0 || index >= db.getNumRecords())
                    throw new FaultException<ServiceFault>(
                        new ServiceFault { Code = "INDEX_OUT_OF_BOUNDS", Message = $"Index {index} is out of range." },
                        new FaultReason("Invalid index"));

                acctNo = db.GetAcctNoByIndex(index);
                pin = db.GetPINByIndex(index);
                bal = db.GetBalanceByIndex(index);
                firstName = db.GetFirstNameByIndex(index);
                lastName = db.GetLastNameByIndex(index);
            }
            catch (FaultException<ServiceFault>) { throw; }
            catch (Exception ex)
            {
                throw new FaultException<ServiceFault>(
                    new ServiceFault { Code = "SERVER_ERROR", Message = ex.Message },
                    new FaultReason("Unexpected server error"));
            }



        }
    }
}
