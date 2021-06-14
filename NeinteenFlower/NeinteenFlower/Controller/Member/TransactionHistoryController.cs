using NeinteenFlower.Handler.Member;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller.Member
{
    public class TransactionHistoryController
    {
        TransactionHistoryHandler handler = new TransactionHistoryHandler();

        public List<TrHeader> GetMemberTransactionHeaderList(string email)
        {
            return handler.GetMemberTransactionHeaderList(email);
        }

        public string CountSubTotal(int flowerID, int quantity)
        {
            MsFlower flower = handler.GetFlowerByID(flowerID);
            if(flower == null)
            {
                return "N/A";
            }

            int totalPrice = flower.FlowerPrice * quantity;
            return totalPrice.ToString();
        }

        public string CountGrandTotal(TrHeader transactionHeader)
        {
            int totalPrice = 0;
            foreach(TrDetail detail in transactionHeader.TrDetails)
            {
                MsFlower flower = handler.GetFlowerByID(detail.FlowerID);
                if (flower == null)
                {
                    return "N/A";
                }

                totalPrice = totalPrice + (flower.FlowerPrice * detail.Quantity);
            }
            
            return totalPrice.ToString();
        }
    }
}