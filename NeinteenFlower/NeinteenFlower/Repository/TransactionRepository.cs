using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class TransactionRepository
    {
        NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();
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

        public List<TrHeader> GetMemberCurrentHeader(int memberID, string date)
        {
            List<TrHeader> headerList = (from data in db.TrHeaders
                                         where data.MemberID == memberID
                                         && data.TransactionDate.Equals(date)
                                         select data).ToList();
            return headerList;
        }
    }
}