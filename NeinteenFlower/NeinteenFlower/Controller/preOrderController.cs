using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class preOrderController
    {
        preOrderHandler poHandler = new preOrderHandler();
        public MsFlower getFlowerById(int id)
        {
            return poHandler.getFlowerById(id);
        }
    }
}