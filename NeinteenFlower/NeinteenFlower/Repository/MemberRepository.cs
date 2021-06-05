using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class MemberRepository
    {
        NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();
        public static MemberRepository shared = new MemberRepository();
        private MemberRepository() { }

        public List<MsMember> GetMemberList()
        {
            List<MsMember> memberList = (from data in db.MsMembers select data).ToList();
            return memberList;
        }

        public void DeleteMember(int id)
        {
            MsMember member = (from memberData in db.MsMembers
                               where memberData.MemberID == id
                               select memberData).FirstOrDefault();
            if(member != null)
            {
                db.MsMembers.Remove(member);
                db.SaveChanges();
            }
        }
    }
}