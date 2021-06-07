using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class UpdateFlowerHandler{
        public void updateFlower(int id, string name, string image, string description, int flowerType, int price)
        {
            FlowerRepository.shared.UpdateFlower(id, name, image, description, flowerType, price);
        }
    }
}