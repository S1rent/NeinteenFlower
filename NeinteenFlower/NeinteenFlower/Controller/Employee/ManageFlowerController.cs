using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class ManageFlowerController
    {
        ManageFlowerHandler dfHandler = new ManageFlowerHandler();
        public void DeleteFlowerById(int id)
        {
            dfHandler.DeleteFlowerById(id);
        }

        public List<MsFlower> GetFlowerList()
        {
            return dfHandler.GetFlowerList();
        }

        public int CheckIfUserIsMember(string email)
        {
            bool isMember = dfHandler.CheckMemberEmailExist(email);
            bool isEmployee = dfHandler.CheckEmployeeEmailExist(email);

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
            MsEmployee employee = dfHandler.GetEmployeeData(email);
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