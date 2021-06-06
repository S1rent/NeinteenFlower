using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class EmployeeFactory
    {
        public static EmployeeFactory shared = new EmployeeFactory();

        public MsEmployee makeEmployee(string email, string password, string name, string birthDate,
                                   string gender, string phoneNumber, string address, int salary)
        {
            MsEmployee employee = new MsEmployee();

            employee.EmployeeName = name;
            employee.EmployeeDOB = birthDate;
            employee.EmployeeGender = gender;
            employee.EmployeeAddress = address;
            employee.EmployeePhone = phoneNumber;
            employee.EmployeeEmail = email;
            employee.EmployeePassword = password;
            employee.EmployeeSalary = salary;

            return employee;
        }

        public MsEmployee makeEmployeeWithID(int id, string email, string password, string name, string birthDate,
                                   string gender, string phoneNumber, string address, int salary)
        {
            MsEmployee employee = new MsEmployee();

            employee.EmployeeID = id;
            employee.EmployeeName = name;
            employee.EmployeeDOB = birthDate;
            employee.EmployeeGender = gender;
            employee.EmployeeAddress = address;
            employee.EmployeePhone = phoneNumber;
            employee.EmployeeEmail = email;
            employee.EmployeePassword = password;
            employee.EmployeeSalary = salary;

            return employee;
        }
    }
}