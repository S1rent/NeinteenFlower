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
    }
}