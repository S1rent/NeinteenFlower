using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class HeaderFooterRepository
    {
        public static HeaderFooterRepository shared = new HeaderFooterRepository();
        NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();
        private HeaderFooterRepository() { }
        public MsEmployee GetEmployeeData(string email)
        {
            MsEmployee employee = (
                from data in db.MsEmployees where data.EmployeeEmail.Equals(email) select data
            ).FirstOrDefault();

            return employee;
        }
    }
}