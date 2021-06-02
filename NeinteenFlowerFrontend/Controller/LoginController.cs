using NeinteenFlower_FrontEnd.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower_FrontEnd.Controller
{
    public class LoginController
    {
        CommonHandlerFrontEnd handler = new CommonHandlerFrontEnd();
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
    }
}