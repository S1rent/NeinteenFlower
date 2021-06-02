using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class RegisterHandler
    {
        public bool CheckEmailExist(string email)
        {
            List<MsMember> memberList = LoginRepository.shared.GetMemberByEmail(email);
            if(memberList.Count == 0)
            {
                return false;
            }
            return true;
        }

        public void InsertMember(MsMember member)
        {
            RegisterRepository.shared.InsertMember(member);
        }
    }
}