using NeinteenFlower.Factory;
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
            return EmployeeRepository.shared.GetEmployeeByEmail(email);
        }

        public bool CheckEmailExist(string email)
        {
            List<MsEmployee> employeeList = EmployeeRepository.shared.GetEmployeeByEmail(email);
            if (employeeList.Count != 0)
            {
                return true;
            }

            List<MsMember> memberList = MemberRepository.shared.GetMemberByEmail(email);
            if (memberList.Count == 0)
            {
                return false;
            }
            return true;
        }

        public void InsertMember(string email, string password, string name, string birthDate,
                    string gender, string phoneNumber, string address)
        {
            MsMember member = MemberFactory.shared.makeMember(
                    email, password, name, birthDate,
                    gender, phoneNumber, address
                );
            MemberRepository.shared.InsertMember(member);
        }
    }
}