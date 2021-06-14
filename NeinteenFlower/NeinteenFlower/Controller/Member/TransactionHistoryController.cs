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
    }
}