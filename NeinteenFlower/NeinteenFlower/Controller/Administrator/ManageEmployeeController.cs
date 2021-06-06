using NeinteenFlower.Handler.Administrator;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller.Administrator
{
    public class ManageEmployeeController
    {
        ManageEmployeeHandler handler = new ManageEmployeeHandler();
        public List<MsEmployee> GetEmployeeList()
        {
            return handler.GetEmployeeList();
        }

        public bool CheckIfUserIsAdministrator(string email)
        {
            if(email.Equals("admin@gmail.com"))
            {
                return true;
            }
            return false;
        }

        public void DeleteEmployee(int id)
        {
            handler.DeleteEmployee(id);
        }
    }
}