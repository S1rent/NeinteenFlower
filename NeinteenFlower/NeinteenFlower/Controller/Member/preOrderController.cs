using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class PreOrderController
    {
        PreOrderHandler poHandler = new PreOrderHandler();
        public MsFlower getFlowerById(int id)
        {
            return poHandler.getFlowerById(id);
        }
        public int CheckIfUserIsMember(string email)
        {
            bool isMember = poHandler.CheckMemberEmailExist(email);
            bool isEmployee = poHandler.CheckEmployeeEmailExist(email);

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
            MsEmployee employee = poHandler.GetEmployeeData(email);
            if (employee != null)
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