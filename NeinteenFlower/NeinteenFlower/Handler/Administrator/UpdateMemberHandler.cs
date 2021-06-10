using NeinteenFlower.Factory;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class UpdateMemberHandler
    {
        public MsMember GetMemberByID(int id)
        {
            return MemberRepository.shared.GetMemberByID(id);
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

        public void UpdateMember(int id, string email, string password, string name, string birthDate,
                    string gender, string phoneNumber, string address)
        {
            MsMember member = MemberFactory.shared.makeMemberWithID(
                id, email, password, name, birthDate,
                gender, phoneNumber, address
            );
            MemberRepository.shared.UpdateMember(member);
        }
    }
}