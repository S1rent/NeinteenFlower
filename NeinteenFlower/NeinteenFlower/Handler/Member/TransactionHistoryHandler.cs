using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler.Member
{
    public class TransactionHistoryHandler
    {
        public List<TrHeader> GetMemberTransactionHeaderList(string email)
        {
            List<MsMember> member = MemberRepository.shared.GetMemberByEmail(email);
            return TransactionRepository.shared.GetAllMemberTransactionHeader(member[0].MemberID);
        }
    }
}