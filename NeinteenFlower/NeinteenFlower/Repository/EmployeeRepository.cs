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

        public List<MsEmployee> GetEmployeeList()
        {
            List<MsEmployee> employeeList = (
                from employeeData in db.MsEmployees
                select employeeData
            ).ToList();
            return employeeList;
        }

        public void InsertEmployee(MsEmployee employee)
        {
            db.MsEmployees.Add(employee);
            db.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            MsEmployee employee = (
                from employeeData in db.MsEmployees
                where employeeData.EmployeeID == id
                select employeeData
            ).FirstOrDefault();

            db.MsEmployees.Remove(employee);
            db.SaveChanges();
        }
    }
}