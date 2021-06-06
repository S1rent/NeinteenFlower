using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler.Administrator
{
    public class ManageEmployeeHandler
    {
        public List<MsEmployee> GetEmployeeList()
        {
            return EmployeeRepository.shared.GetEmployeeList();
        }

        public void DeleteEmployee(int id)
        {
            EmployeeRepository.shared.DeleteEmployee(id);
        }
    }
}