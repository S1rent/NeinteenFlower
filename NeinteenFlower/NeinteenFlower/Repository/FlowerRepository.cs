using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class FlowerRepository
    {
        NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();
        public static FlowerRepository shared = new FlowerRepository();
        private FlowerRepository() { }

        public List<MsFlower> GetFlowerList()
        {
            List<MsFlower> flowerList = (from data in db.MsFlowers select data).ToList();
            return flowerList;
        }
    }
}