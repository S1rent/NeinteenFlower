using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class HeaderFooterController
    {
        HeaderFooterHandler handler = new HeaderFooterHandler();

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
        public int CheckIfEmployeeIsAdministrator(string email)
        {
            MsEmployee employee = handler.GetEmployeeData(email);
            if(employee != null)
            {
                if (employee.EmployeeEmail.Equals("admin@gmail.com"))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            return -1;
        }
    }
}