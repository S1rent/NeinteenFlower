﻿using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler.Administrator
{
    public class UpdateEmployeeHandler
    {
        public MsEmployee GetEmployeeByID(int id)
        {
            return EmployeeRepository.shared.GetEmployeeByID(id);
        }

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

        public void UpdateEmployee(MsEmployee employee)
        {
            EmployeeRepository.shared.UpdateEmployee(employee);
        }
    }
}