using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class TransactionFactory
    {
        public static TransactionFactory shared = new TransactionFactory();

        public TrHeader makeHeader(int memberID, string date)
        {
            TrHeader header = new TrHeader();
            header.MemberID = memberID;
            header.TransactionDate = date;

            return header;
        }

        public TrDetail makeDetail(int transactionID, int flowerID, int quantity)
        {
            TrDetail detail = new TrDetail();
            detail.TransactionID = transactionID;
            detail.FlowerID = flowerID;
            detail.Quantity = quantity;

            return detail;
        }
    }
}