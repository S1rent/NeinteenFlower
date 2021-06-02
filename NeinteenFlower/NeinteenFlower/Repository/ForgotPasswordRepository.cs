using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class ForgotPasswordRepository
    {
        public static ForgotPasswordRepository shared = new ForgotPasswordRepository();
        NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();
        private ForgotPasswordRepository() { }
        public void UpdateMemberPassword(string email, string password)
        {
            MsMember member = (from data in db.MsMembers where data.MemberEmail.Equals(email) select data).FirstOrDefault();
            if (member != null)
            {
                member.MemberPassword = password;
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