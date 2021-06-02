using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class RegisterRepository
    {
        public static RegisterRepository shared = new RegisterRepository();
        NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();
        private RegisterRepository() { }
        public void InsertMember(MsMember member)
        {
            db.MsMembers.Add(member);
            db.SaveChanges();
        }
    }
}