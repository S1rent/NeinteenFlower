using NeinteenFlower.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class ForgotPasswordController
    {
        ForgotPasswordHandler handler = new ForgotPasswordHandler();
        public ForgotPasswordController() { }
        public string ForgotPassword(string email, string password, string captcha)
        {
            bool isEmployeeEmailExist = handler.CheckEmployeeEmailExist(email);
            bool isMemberEmailExist = handler.CheckMemberEmailExist(email);

            if (email.Length == 0)
            {
                return "Email cannot be empty.";
            }
            else if (password.Length == 0)
            {
                return "Password cannot be empty.";
            }
            else if (!password.Equals(captcha))
            {
                return "Password must be the same as captcha.";
            }
            else if(!isEmployeeEmailExist && !isMemberEmailExist)
            {
                return "Email doesn't exist.";
            }

            if(isEmployeeEmailExist)
            {
                handler.UpdatePassword(email, password, false);
            }
            else if(isMemberEmailExist)
            {
                handler.UpdatePassword(email, password, true);
            }

            return "";
        }

        public string GenerateCaptcha()
        {
            string alphabetPool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numberPool = "0123456789";
            string captcha = "";
            Random rand = new Random();

            for(int i=0;i<3;i++)
            {
                captcha = captcha + alphabetPool[rand.Next(alphabetPool.Length)];
            }

            for (int i = 0; i < 3; i++)
            {
                captcha = captcha + numberPool[rand.Next(numberPool.Length)];
            }
            return captcha;
        }
    }
}