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
        public void insertFlower(string name, string image, string description, int flowerType, int price)
        {
            FlowerFactory ff = new FlowerFactory();

            MsFlower mf = ff.createFlower(name, image, description, flowerType, price);
            FlowerRepository.shared.insertFlower(mf);
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
        public MsEmployee GetEmployeeData(string email)
        {
            return HeaderFooterRepository.shared.GetEmployeeData(email);
        }
    }
}