using NeinteenFlower.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class DeleteFlowerController
    {
        DeleteFlowerHandler dfHandler = new DeleteFlowerHandler();
        public void deleteFlowerById(int id)
        {
            dfHandler.deleteFlowerById(id);
        }
    }
}