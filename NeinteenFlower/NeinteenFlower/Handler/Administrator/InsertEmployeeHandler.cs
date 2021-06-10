using NeinteenFlower.Factory;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler.Administrator
{
    public class InsertEmployeeHandler
    {
        public bool CheckEmailExist(string email)
        {
            List<MsEmployee> employeeList = EmployeeRepository.shared.GetEmployeeByEmail(email);
            if (employeeList.Count != 0)
            {
                return true;
            }

            List<MsMember> memberList = MemberRepository.shared.GetMemberByEmail(email);
            if (memberList.Count == 0)
            {
                return false;
            }
            return true;
        }

        public void InsertEmployee(string email, string password, string name, string birthDate,
                        string gender, string phoneNumber, string address, int convertedSalary)
        {
            MsEmployee employee = EmployeeFactory.shared.makeEmployee(
                                        email, password, name, birthDate,
                                        gender, phoneNumber, address, convertedSalary
                                    );
            EmployeeRepository.shared.InsertEmployee(employee);
        }
    }
}