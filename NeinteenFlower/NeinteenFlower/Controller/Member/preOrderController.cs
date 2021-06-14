using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class PreOrderController
    {
        PreOrderHandler poHandler = new PreOrderHandler();
        public MsFlower GetFlowerById(int id)
        {
            return poHandler.GetFlowerById(id);
        }

        public int CheckIfUserIsMember(string email)
        {
            bool isMember = poHandler.CheckMemberEmailExist(email);

            if (isMember)
            {
                return 1;
            }

            return -1;
        }

        public string PreOrder(string quantity, string id, string memberEmail)
        {
            int convertedQuantity = -1, convertedID = -1;
            try
            {
                convertedQuantity = Int16.Parse(quantity);
                convertedID = Int16.Parse(id);
            }
            catch
            {
                convertedID = -1;
                return "Quantity must be number";
            }

            if (convertedID == -1)
            {
                return "err/invalid_id";
            }
            else if (memberEmail == null)
            {
                return "err/invalid_member";
            }

            MsFlower flower = this.GetFlowerById(convertedID);
            MsMember member = poHandler.GetMemberByEmail(memberEmail);
            if (flower == null)
            {
                return "err/invalid_id";
            }
            if (member == null)
            {
                return "err/invalid_member";
            }

            if (convertedQuantity < 1 || convertedQuantity > 100)
            {
                return "Quantity must be at least 1 and maximum of 100.";
            }

            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");

            poHandler.PreOrder(convertedID, member.MemberID, convertedQuantity, currentDate);

            return "";
        }
    }
}