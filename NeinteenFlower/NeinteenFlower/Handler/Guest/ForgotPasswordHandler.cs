using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class ForgotPasswordHandler
    {
        public bool CheckMemberEmailExist(string email)
        {
            List<MsMember> memberList = MemberRepository.shared.GetMemberByEmail(email);
            if (memberList.Count == 0)
            {
                return false;
            }
            return true;
        }
        public bool CheckEmployeeEmailExist(string email)
        {
            List<MsEmployee> employeeList = EmployeeRepository.shared.GetEmployeeByEmail(email);
            if (employeeList.Count == 0)
            {
                return false;
            }
            return true;
        }

        public void UpdatePassword(string email, string password, bool isMember)
        {
            if(isMember)
            {
                MemberRepository.shared.UpdateMemberPassword(email, password);
            }
            else
            {
                EmployeeRepository.shared.UpdateEmployeePassword(email, password);
            }
        }
    }
}