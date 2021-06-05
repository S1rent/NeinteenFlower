using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class ManageMemberHandler
    {
        public List<MsMember> GetMemberList()
        {
            return MemberRepository.shared.GetMemberList();
        }

        public List<MsEmployee> GetEmployeeListByEmail(string email)
        {
            return EmployeeRepository.shared.GetEmployeeByEmail(email);
        }

        public void DeleteMember(int id)
        {
            MemberRepository.shared.DeleteMember(id);
        }
    }
}