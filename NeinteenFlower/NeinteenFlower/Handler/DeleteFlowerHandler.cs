using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class DeleteFlowerHandler
    {
        public void deleteFlowerById(int id)
        {
            FlowerRepository.shared.deleteFlowerById(id);
        }
    }
}