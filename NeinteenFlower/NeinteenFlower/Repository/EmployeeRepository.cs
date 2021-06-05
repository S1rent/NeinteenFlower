using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class EmployeeRepository
    {
        NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();
        public static EmployeeRepository shared = new EmployeeRepository();
        private EmployeeRepository() { }

        public List<MsEmployee> GetEmployeeByEmail(string email)
        {
            List<MsEmployee> employeeList = (
                from employeeData in db.MsEmployees
                where employeeData.EmployeeEmail.Equals(email)
                select employeeData
            ).ToList();

            return employeeList;
        }
    }
}