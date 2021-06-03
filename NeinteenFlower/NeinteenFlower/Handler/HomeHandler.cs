using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class HomeHandler
    {
        public List<MsFlower> GetFlowerList()
        {
            return FlowerRepository.shared.GetFlowerList();
        }
        public bool CheckMemberEmailExist(string email)
        {
            if (LoginRepository.shared.GetMemberByEmail(email).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckEmployeeEmailExist(string email)
        {
            if (LoginRepository.shared.GetEmployeeByEmail(email).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}