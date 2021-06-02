using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class MemberFactory
    {
        public static MemberFactory shared = new MemberFactory();

        public MsMember makeMember(string email, string password, string name, string birthDate,
                                   string gender, string phoneNumber, string address)
        {
            MsMember member = new MsMember();

            member.MemberName = name;
            member.MemberDOB = birthDate;
            member.MemberGender = gender;
            member.MemberAddress = address;
            member.MemberPhone = phoneNumber;
            member.MemberEmail = email;
            member.MemberPassword = password;

            return member;
        }
    }
}