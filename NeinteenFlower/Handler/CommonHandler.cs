using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class CommonHandler
    {
        public static CommonHandler shared = new CommonHandler();
        public string CheckUserEmailExist(string email)
        {
            if(CommonRepository.shared.GetEmployeeByEmail(email).Count != 0)
            {
                return JSONHandler.shared.Encode(true);
            }
            else if(CommonRepository.shared.GetMemberByEmail(email).Count != 0)
            {
                return JSONHandler.shared.Encode(true);
            }
            else
            {
                return JSONHandler.shared.Encode(false);
            }
        }

        public string ValidatePassword(bool isEmployee, string email, string password)
        {
            if (isEmployee)
            {
                List<MsEmployee> employeeList = CommonRepository.shared.GetEmployeeByEmail(email);

                if (employeeList.Count == 0)
                {
                    return JSONHandler.shared.Encode(false);
                }
                else
                {
                    if (employeeList[0].EmployeePassword.Equals(password))
                    {
                        return JSONHandler.shared.Encode(true);
                    }
                    else
                    {
                        return JSONHandler.shared.Encode(false);
                    }
                }
            }
            else
            {
                List<MsMember> memberList = CommonRepository.shared.GetMemberByEmail(email);

                if (memberList.Count == 0)
                {
                    return JSONHandler.shared.Encode(false);
                }
                else
                {
                    if (memberList[0].MemberPassword.Equals(password))
                    {
                        return JSONHandler.shared.Encode(true);
                    }
                    else
                    {
                        return JSONHandler.shared.Encode(false);
                    }
                }
            }
        }
    }
}