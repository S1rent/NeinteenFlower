using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class FlowerRepository
    {
        NeinteenFlowerDBEntities1 db = new NeinteenFlowerDBEntities1();
        public static FlowerRepository shared = new FlowerRepository();
        private FlowerRepository() { }

        public List<MsFlower> GetFlowerList()
        {
            List<MsFlower> flowerList = (
                from data in db.MsFlowers
                where data.IsDeleted == 0
                select data
                ).ToList();
            return flowerList;
        }

        public MsFlower GetFlowerById(int id)
        {
            return (from x in db.MsFlowers 
                    join y in db.MsFlowerTypes
                    on x.FlowerTypeID equals y.FlowerTypeID
                    where x.FlowerID == id select x).FirstOrDefault();
        }

        public void DeleteFlowerById(int id)
        {
            MsFlower f = (from x in db.MsFlowers
                          where x.FlowerID == id
                          select x).FirstOrDefault();
            if(f != null)
            {
                f.IsDeleted = 1;
                db.SaveChanges();
            }
        }

        public void HardDeleteFlowerById(int id)
        {
            MsFlower f = (from x in db.MsFlowers
                          where x.FlowerID == id
                          select x).FirstOrDefault();
            if (f != null)
            {
                db.MsFlowers.Remove(f);
                db.SaveChanges();
            }
        }

        public void InsertFlower(MsFlower flower)
        {
            db.MsFlowers.Add(flower);
            db.SaveChanges();
        }

        public void UpdateFlower(MsFlower flower)
        {
            MsFlower dbFlower = (from x in db.MsFlowers
                                 where x.FlowerID == flower.FlowerID
                                 select x).FirstOrDefault();

            if(dbFlower != null)
            {
                dbFlower.FlowerName = flower.FlowerName;
                dbFlower.FlowerDescription = flower.FlowerDescription;
                dbFlower.FlowerImage = flower.FlowerImage;
                dbFlower.FlowerPrice = flower.FlowerPrice;
                dbFlower.FlowerTypeID = flower.FlowerTypeID;

                db.SaveChanges();
            }
        }
    }
}