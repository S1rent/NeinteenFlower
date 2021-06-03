using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class HomeController
    {
        HomeHandler handler = new HomeHandler();
        public List<MsFlower> GetFlowerList()
        {
            return handler.GetFlowerList();
        }

        public int CheckIfUserIsMember(string email)
        {
            bool isMember = handler.CheckMemberEmailExist(email);
            bool isEmployee = handler.CheckEmployeeEmailExist(email);

            if (isMember)
            {
                return 1;
            }
            else if (isEmployee)
            {
                return 0;
            }

            return -1;
        }
    }
}