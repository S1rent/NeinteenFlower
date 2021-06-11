using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class ManageMemberHandler
    {
        public List<MsMember> GetMemberList()
        {
            return MemberRepository.shared.GetMemberList();
        }

        public List<MsEmployee> GetEmployeeListByEmail(string email)
        {
            return EmployeeRepository.shared.GetEmployeeByEmail(email);
        }

        public void DeleteMember(int id)
        {
            List<TrHeader> memberTransactionHeaderList = TransactionRepository.shared.GetAllMemberTransactionHeader(id);
            if (memberTransactionHeaderList.Count != 0)
            {
                for(int i=0;i<memberTransactionHeaderList.Count;i++)
                {
                    int transactionID = memberTransactionHeaderList[i].TransactionID;
                    List<TrDetail> detailList = TransactionRepository.shared.GetAllMemberTransactionDetail(transactionID);
                    for(int j=0;j<detailList.Count;j++)
                    {
                        int flowerID = detailList[j].FlowerID;
                        TransactionRepository.shared.DeleteMemberTransactionDetail(transactionID, flowerID);
                    }
                    TransactionRepository.shared.DeleteMemberTransactionHeader(id, transactionID);
                }
                MemberRepository.shared.DeleteMember(id);
            }
            else
            {
                MemberRepository.shared.DeleteMember(id);
            }
        }
    }
}