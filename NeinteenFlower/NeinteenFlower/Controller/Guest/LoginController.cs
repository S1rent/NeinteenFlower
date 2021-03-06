using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower_FrontEnd.Controller
{
    public class LoginController
    {
        LoginHandler handler = new LoginHandler();
        public LoginController() { }
        public string Login(string email, string password)
        {
            bool isMember = handler.CheckMemberEmailExist(email);
            bool isEmployee = handler.CheckEmployeeEmailExist(email);

            if (email.Length == 0)
            {
                return "Email cannot be empty.";
            }
            else if (password.Length == 0)
            {
                return "Password cannot be empty.";
            }
            else if (!isMember && !isEmployee)
            {
                return "Email is not found.";
            }
            else if (isMember)
            {
                bool isPasswordValid = handler.ValidatePassword(false, email, password);
                if (isPasswordValid)
                {
                    return "";
                }
                else
                {
                    return "Wrong password.";
                }
            }
            else if (isEmployee)
            {
                bool isPasswordValid = handler.ValidatePassword(true, email, password);
                if (isPasswordValid)
                {
                    return "";
                }
                else
                {
                    return "Wrong password.";
                }
            }
            else
            {
                return "Error, Please try again later.";
            }
        }

        public string GetUsername(string email)
        {
            bool isMember = handler.CheckMemberEmailExist(email);
            bool isEmployee = handler.CheckEmployeeEmailExist(email);

            if (isMember)
            {
                MsMember member = handler.GetMember(email);
                return member.MemberName;
            }
            else
            {
                MsEmployee employee = handler.GetEmployee(email);
                return employee.EmployeeName;
            }
        }
    }
}