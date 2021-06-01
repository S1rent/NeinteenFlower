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
        public bool CheckUserEmailExist(string email)
        {
            return handler.CheckUserEmailExist(email);
        }

        public bool ValidatePassword(bool isEmployee, string email, string password)
        {
            return handler.ValidatePassword(isEmployee, email, password);
        }
    }
}