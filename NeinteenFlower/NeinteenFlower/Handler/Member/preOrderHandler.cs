using NeinteenFlower.Factory;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class PreOrderHandler
    {
        public MsFlower GetFlowerById(int id)
        {
            return FlowerRepository.shared.GetFlowerById(id);
        }

        public MsMember GetMemberByEmail(string email)
        {
            return MemberRepository.shared.GetSingleMemberByEmail(email);
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

        public void PreOrder(int flowerID, int memberID, int quantity, string currentDate)
        {
            List<TrHeader> headerList = TransactionRepository.shared.GetMemberCurrentTransactionHeader(memberID, currentDate);
            // udh pernah pre order
            if(headerList.Count != 0)
            {
                int transactionID = TransactionRepository.shared.GetMemberCurrentTransactionHeader(memberID, currentDate)[0].TransactionID;
                // udh ada detail yg isinya flower yg sama
                if(TransactionRepository.shared.CheckAlreadyBuyFlower(transactionID, flowerID))
                {
                    TransactionRepository.shared.UpdateTransactionDetailFlowerQuantity(transactionID, flowerID, quantity);
                }
                else
                {
                    // belom ada
                    TrDetail detail = TransactionFactory.shared.makeDetail(transactionID, flowerID, quantity);
                    TransactionRepository.shared.InsertTransactionDetail(detail);
                }
            }
            else
            {
                // Belom Pernah preorder di hari itu
                TrHeader header = TransactionFactory.shared.makeHeader(memberID, currentDate);
                TransactionRepository.shared.InsertTransactionHeader(header);

                int transactionID = TransactionRepository.shared.GetMemberCurrentTransactionHeader(memberID, currentDate)[0].TransactionID;
                TrDetail detail = TransactionFactory.shared.makeDetail(transactionID, flowerID, quantity);
                TransactionRepository.shared.InsertTransactionDetail(detail);
            }
        }
    }
}