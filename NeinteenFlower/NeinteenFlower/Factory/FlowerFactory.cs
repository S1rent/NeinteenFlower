using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class FlowerFactory
    {
        public MsFlower createFlower(string name, string image, string description, int flowerType, int price)
        {
            MsFlower mf = new MsFlower();
            mf.FlowerName = name;
            mf.FlowerImage = image;
            mf.FlowerPrice = price;
            mf.FlowerDescription = description;
            mf.FlowerTypeID = flowerType;

            return mf;
        }
    }
}