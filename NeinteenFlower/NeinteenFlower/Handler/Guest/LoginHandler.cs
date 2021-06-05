using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class LoginHandler
    {
        public bool CheckMemberEmailExist(string email)
        {
            if (MemberRepository.shared.GetMemberByEmail(email).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckEmployeeEmailExist(string email)
        {
            if (EmployeeRepository.shared.GetEmployeeByEmail(email).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidatePassword(bool isEmployee, string email, string password)
        {
            if (isEmployee)
            {
                List<MsEmployee> employeeList = EmployeeRepository.shared.GetEmployeeByEmail(email);

                if (employeeList.Count == 0)
                {
                    return false;
                }
                else
                {
                    if (employeeList[0].EmployeePassword.Equals(password))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                List<MsMember> memberList = MemberRepository.shared.GetMemberByEmail(email);

                if (memberList.Count == 0)
                {
                    return false;
                }
                else
                {
                    if (memberList[0].MemberPassword.Equals(password))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public MsMember GetMember(string email)
        {
            List<MsMember> memberList = MemberRepository.shared.GetMemberByEmail(email);
            return memberList[0];
        }
        public MsEmployee GetEmployee(string email)
        {
            List<MsEmployee> employeeList = EmployeeRepository.shared.GetEmployeeByEmail(email);
            return employeeList[0];
        }
    }
}