using NeinteenFlower.Handler;
using NeinteenFlower.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower_FrontEnd.Handler
{
    public class CommonHandlerFrontEnd
    {
        public NeinteenFlowerWebService webService = new NeinteenFlowerWebService();
        public CommonHandlerFrontEnd() { }

        public bool CheckMemberEmailExist(string email)
        {
            string isUserEmailExist = webService.CheckMemberEmailExist(email);
            return JSONHandler.shared.Decode<bool>(isUserEmailExist);
        }

        public bool CheckEmployeeEmailExist(string email)
        {
            string isUserEmailExist = webService.CheckEmployeeEmailExist(email);
            return JSONHandler.shared.Decode<bool>(isUserEmailExist);
        }

        public bool ValidatePassword(bool isEmployee, string email, string password)
        {
            string isPasswordValid = webService.ValidatePassword(isEmployee, email, password);
            return JSONHandler.shared.Decode<bool>(isPasswordValid);
        }
    }
}