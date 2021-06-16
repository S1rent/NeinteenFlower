using NeinteenFlower.Factory;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class UpdateFlowerHandler {

        public List<MsEmployee> GetEmployeeByEmail(string email)
        {
            return EmployeeRepository.shared.GetEmployeeByEmail(email);
        }

        public void updateFlower(int id, string name, string image, string description, int flowerType, int price, int isDeleted)
        {
            MsFlower newFlower = FlowerFactory.shared.createFlowerWithID(id, name, image, description, flowerType, price, isDeleted);
            FlowerRepository.shared.UpdateFlower(newFlower);
        }

        public MsFlower GetFlowerByID(int id)
        {
            return FlowerRepository.shared.GetFlowerById(id);
        }
    }
}