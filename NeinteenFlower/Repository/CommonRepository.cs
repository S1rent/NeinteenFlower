using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower
{
    public class CommonRepository
    {
        public static List<MsEmployee> GetEmployeeByEmail(string email)
        {
            NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();
            List<MsEmployee> employeeList = (
                from employeeData in db.MsEmployees
                where employeeData.EmployeeEmail.Equals(email)
                select employeeData
            ).ToList();

            return employeeList;
        }

        public static List<MsMember> GetMemberByEmail(string email)
        {
            NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();
            List<MsMember> memberList = (
                from memberData in db.MsMembers
                where memberData.MemberEmail.Equals(email)
                select memberData
            ).ToList();

            return memberList;
        }
    }
}