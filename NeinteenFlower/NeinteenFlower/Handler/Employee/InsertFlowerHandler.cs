using NeinteenFlower.Factory;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class InsertFlowerHandler
    {
        public void InsertFlower(string name, string image, string description, int flowerType, int price)
        {
            MsFlower mf = FlowerFactory.shared.createFlower(name, image, description, flowerType, price);
            FlowerRepository.shared.InsertFlower(mf);
        }
        public bool CheckMemberEmailExist(string email)
        {
            if (MemberRepository.shared.GetMemberByEmail(email).Count != 0)
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
            if (EmployeeRepository.shared.GetEmployeeByEmail(email).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public MsEmployee GetEmployeeData(string email)
        {
            return EmployeeRepository.shared.GetEmployeeData(email);
        }
    }
}