using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class ManageFlowerHandler
    {
        public void DeleteFlowerById(int id)
        {
            List<TrDetail> transactionList = TransactionRepository.shared.GetTransactionDetailByFlowerID(id);
            if(transactionList.Count == 0)
            {
                //Hard Delete
                FlowerRepository.shared.HardDeleteFlowerById(id);
            }
            else
            {
                //Soft Delete
                FlowerRepository.shared.DeleteFlowerById(id);
            }
        }
        public List<MsFlower> GetFlowerList()
        {
            return FlowerRepository.shared.GetFlowerList();
        }
        public bool CheckMemberEmailExist(string email)
        {
            if (MemberRepository.shared.GetMemberByEmail(email).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckEmployeeEmailExist(string email)
        {
            if (EmployeeRepository.shared.GetEmployeeByEmail(email).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public MsEmployee GetEmployeeData(string email)
        {
            return EmployeeRepository.shared.GetEmployeeData(email);
        }
    }
}