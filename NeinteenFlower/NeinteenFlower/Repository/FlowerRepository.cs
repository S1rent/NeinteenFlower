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

        public MsFlower getFlowerById(int id)
        {
            return (from x in db.MsFlowers 
                    join y in db.MsFlowerTypes
                    on x.FlowerTypeID equals y.FlowerTypeID
                    where x.FlowerID == id select x).FirstOrDefault();
        }

        public void deleteFlowerById(int id)
        {
            MsFlower f = (from x in db.MsFlowers
                          where x.FlowerID == id
                          select x).FirstOrDefault();
            db.MsFlowers.Remove(f);
            db.SaveChanges();
        }

        public void insertFlower(MsFlower flower)
        {
            db.MsFlowers.Add(flower);
            db.SaveChanges();
        }

        public void updateFlower(int id, string name, string image, string description, int flowerType, int price)
        {
            MsFlower f = (from x in db.MsFlowers
                          where x.FlowerID == id
                          select x).FirstOrDefault();
            f.FlowerName = name;
            f.FlowerDescription = description;
            f.FlowerImage = image;
            f.FlowerPrice = price;
            f.FlowerTypeID = flowerType;

            db.SaveChanges();
        }
    }
}