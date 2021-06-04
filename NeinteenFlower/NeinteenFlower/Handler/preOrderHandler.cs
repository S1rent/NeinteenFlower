using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class preOrderHandler
    {
        public MsFlower getFlowerById(int id)
        {
            return FlowerRepository.shared.getFlowerById(id);
        }

    }
}