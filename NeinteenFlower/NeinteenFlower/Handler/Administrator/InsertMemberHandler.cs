using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class InsertMemberHandler
    {
        public List<MsEmployee> GetEmployeeListByEmail(string email)
        {
            return LoginRepository.shared.GetEmployeeByEmail(email);
        }

        public bool CheckEmailExist(string email)
        {
            List<MsEmployee> employeeList = LoginRepository.shared.GetEmployeeByEmail(email);
            if (employeeList.Count != 0)
            {
                return true;
            }

            List<MsMember> memberList = LoginRepository.shared.GetMemberByEmail(email);
            if (memberList.Count == 0)
            {
                return false;
            }
            return true;
        }

        public void InsertMember(MsMember member)
        {
            MemberRepository.shared.InsertMember(member);
        }
    }
}