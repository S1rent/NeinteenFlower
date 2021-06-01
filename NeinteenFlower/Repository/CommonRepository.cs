using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower
{
    public class CommonRepository
    {
        public NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();
        public static CommonRepository shared = new CommonRepository();
        private CommonRepository() { }

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