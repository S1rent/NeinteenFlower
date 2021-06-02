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
            List<MsMember> memberList = LoginRepository.shared.GetMemberByEmail(email);
            if (memberList.Count == 0)
            {
                return false;
            }
            return true;
        }
        public bool CheckEmployeeEmailExist(string email)
        {
            List<MsEmployee> employeeList = LoginRepository.shared.GetEmployeeByEmail(email);
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
                ForgotPasswordRepository.shared.UpdateMemberPassword(email, password);
            }
            else
            {
                ForgotPasswordRepository.shared.UpdateEmployeePassword(email, password);
            }
        }
    }
}