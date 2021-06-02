using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class LoginRepository
    {
        public static LoginRepository shared = new LoginRepository();
        NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();
        private LoginRepository() { }
        public List<MsEmployee> GetEmployeeByEmail(string email)
        {
            List<MsEmployee> employeeList = (
                from employeeData in db.MsEmployees
                where employeeData.EmployeeEmail.Equals(email)
                select employeeData
            ).ToList();

            return employeeList;
        }

        public List<MsMember> GetMemberByEmail(string email)
        {
            List<MsMember> memberList = (
                from memberData in db.MsMembers
                where memberData.MemberEmail.Equals(email)
                select memberData
            ).ToList();

            return memberList;
        }
    }
}