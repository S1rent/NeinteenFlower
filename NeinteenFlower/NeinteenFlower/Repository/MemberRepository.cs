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

        public List<MsMember> GetMemberByEmail(string email)
        {
            List<MsMember> memberList = (
                from memberData in db.MsMembers
                where memberData.MemberEmail.Equals(email)
                select memberData
            ).ToList();

            return memberList;
        }

        public MsMember GetSingleMemberByEmail(string email)
        {
            MsMember member = (
                from memberData in db.MsMembers
                where memberData.MemberEmail.Equals(email)
                select memberData
            ).FirstOrDefault();

            return member;
        }

        public void InsertMember(MsMember member)
        {
            db.MsMembers.Add(member);
            db.SaveChanges();
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

        public MsMember GetMemberByID(int id)
        {
            MsMember memberList = (from memberData in db.MsMembers
                                         where memberData.MemberID == id
                                         select memberData).FirstOrDefault();
            return memberList;
        }

        public void UpdateMember(MsMember member)
        {
            MsMember dbMemberData = (from memberData in db.MsMembers
                          where memberData.MemberID == member.MemberID
                          select memberData).FirstOrDefault();

            if(dbMemberData != null)
            {
                dbMemberData.MemberName = member.MemberName;
                dbMemberData.MemberAddress = member.MemberAddress;
                dbMemberData.MemberDOB = member.MemberDOB;
                dbMemberData.MemberEmail = member.MemberEmail;
                dbMemberData.MemberGender = member.MemberGender;
                dbMemberData.MemberPassword = member.MemberPassword;
                dbMemberData.MemberPhone = member.MemberPhone;

                db.SaveChanges();
            }
        }
    }
}