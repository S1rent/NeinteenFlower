using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class FlowerFactory
    {
        public static FlowerFactory shared = new FlowerFactory();
        private FlowerFactory() { }

        public MsFlower createFlower(string name, string image, string description, int flowerType, int price)
        {
            MsFlower mf = new MsFlower();
            mf.FlowerName = name;
            mf.FlowerImage = image;
            mf.FlowerPrice = price;
            mf.FlowerDescription = description;
            mf.FlowerTypeID = flowerType;
            mf.IsDeleted = 0;

            return mf;
        }

        public MsFlower createFlowerWithID(int id, string name, string image, string description, int flowerType, int price, int isDeleted)
        {
            MsFlower mf = new MsFlower();
            mf.FlowerID = id;
            mf.FlowerName = name;
            mf.FlowerImage = image;
            mf.FlowerPrice = price;
            mf.FlowerDescription = description;
            mf.FlowerTypeID = flowerType;
            mf.IsDeleted = isDeleted;

            return mf;
        }
    }
}