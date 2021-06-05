using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class ManageMemberController
    {
        ManageMemberHandler handler = new ManageMemberHandler();

        public List<MsMember> GetMemberList()
        {
            return handler.GetMemberList();
        }

        public bool CheckIfUserIsAdministrator(string email)
        {
            List<MsEmployee> employeeList = handler.GetEmployeeListByEmail(email);
            if(employeeList.Count == 0)
            {
                return false;
            }
            else
            {
                if(employeeList[0].EmployeeEmail.Equals("admin@gmail.com"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void DeleteMember(int id)
        {
            handler.DeleteMember(id);
        }
    }
}