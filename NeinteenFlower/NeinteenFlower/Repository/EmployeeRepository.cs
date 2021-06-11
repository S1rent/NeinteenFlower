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

        public MsEmployee GetEmployeeByID(int id)
        {
            MsEmployee employee = (from employeeData in db.MsEmployees
                                   where employeeData.EmployeeID == id
                                   select employeeData).FirstOrDefault();
            return employee;
        }

        public void UpdateEmployee(MsEmployee employee)
        {
            MsEmployee dbEmployeeData = (from employeeData in db.MsEmployees
                                         where employeeData.EmployeeID == employee.EmployeeID
                                        select employeeData).FirstOrDefault();

            if (dbEmployeeData != null)
            {
                dbEmployeeData.EmployeeName = employee.EmployeeName;
                dbEmployeeData.EmployeeAddress = employee.EmployeeAddress;
                dbEmployeeData.EmployeeDOB = employee.EmployeeDOB;
                dbEmployeeData.EmployeeEmail = employee.EmployeeEmail;
                dbEmployeeData.EmployeeGender = employee.EmployeeGender;
                dbEmployeeData.EmployeePassword = employee.EmployeePassword;
                dbEmployeeData.EmployeePhone = employee.EmployeePhone;
                dbEmployeeData.EmployeeSalary = employee.EmployeeSalary;

                db.SaveChanges();
            }
        }

        public void UpdateEmployeePassword(string email, string password)
        {
            MsEmployee employee = (from data in db.MsEmployees where data.EmployeeEmail.Equals(email) select data).FirstOrDefault();
            if (employee != null)
            {
                employee.EmployeePassword = password;
                db.SaveChanges();
            }
        }
    }
}