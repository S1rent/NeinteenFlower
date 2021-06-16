using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class TransactionRepository
    {
        NeinteenFlowerDBEntities1 db = new NeinteenFlowerDBEntities1();
        public static TransactionRepository shared = new TransactionRepository();
        private TransactionRepository() { }

        public void InsertTransactionHeader(TrHeader header)
        {
            db.TrHeaders.Add(header);
            db.SaveChanges();
        }

        public void InsertTransactionDetail(TrDetail detail)
        {
            db.TrDetails.Add(detail);
            db.SaveChanges();
        }

        public List<TrHeader> GetMemberCurrentTransactionHeader(int memberID, string date)
        {
            List<TrHeader> headerList = (from data in db.TrHeaders
                                         where data.MemberID == memberID
                                         && data.TransactionDate.Equals(date)
                                         select data).ToList();
            return headerList;
        }

        public List<TrHeader> GetAllMemberTransactionHeader(int memberID)
        {
            List<TrHeader> headerList = (from data in db.TrHeaders
                                         where data.MemberID == memberID
                                         select data).ToList();
            return headerList;
        }

        public List<TrDetail> GetAllMemberTransactionDetail(int transactionID)
        {
            List<TrDetail> detailList = (from data in db.TrDetails
                                         where data.TransactionID == transactionID
                                         select data).ToList();
            return detailList;
        }

        public void DeleteMemberTransactionDetail(int transactionID, int flowerID)
        {
            TrDetail detail = (from data in db.TrDetails
                               where data.TransactionID == transactionID
                               && data.FlowerID == flowerID
                               select data).FirstOrDefault();
            if (detail != null)
            {
                db.TrDetails.Remove(detail);
                db.SaveChanges();
            }
        }

        public void DeleteMemberTransactionHeader(int memberID, int transactionID)
        {
            TrHeader header = (from data in db.TrHeaders
                               where data.MemberID == memberID
                               && data.TransactionID == transactionID
                               select data).FirstOrDefault();
            if (header != null)
            {
                db.TrHeaders.Remove(header);
                db.SaveChanges();
            }
        }

        public bool CheckAlreadyBuyFlower(int transactionID, int flowerID)
        {
            List<TrDetail> detailList = (from data in db.TrDetails
                                         where data.TransactionID == transactionID
                                         && data.FlowerID == flowerID
                                         select data).ToList();

            return (detailList.Count == 0) ? false : true ;
        }

        public void UpdateTransactionDetailFlowerQuantity(int transactionID, int flowerID, int quantity)
        {
            TrDetail detailData = (from data in db.TrDetails
                                   where data.TransactionID == transactionID
                                   && data.FlowerID == flowerID
                                   select data).FirstOrDefault();

            if (detailData != null)
            {
                detailData.Quantity += quantity;

                db.SaveChanges();
            }
        }
    }
}