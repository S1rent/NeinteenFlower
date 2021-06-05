using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class InsertFlowerController
    {
        InsertFlowerHandler ifh = new InsertFlowerHandler();
        public string InsertFlower(string name, HttpPostedFile image, string description, String flowerType, String price)
        {
            int pricee = 0;
            string fileLoc = "";
            int flowerTypeId = 0;

            if (name.Equals(""))
            {
                return "Name must be filled!";
            }
            else
            {
                if (name.Length < 5)
                {
                    return "Minimal name length is 5 characters";
                }
            }

            if (!System.IO.Path.GetExtension(image.FileName).Equals(".jpg"))
            {
                return "Image extension must ends with “.jpg” ";
            }
            else
            {
                var filepath = HttpContext.Current.Server.MapPath("~/Assets/" + image.FileName);
                image.SaveAs(filepath);
                fileLoc = "../Assets/" + image.FileName;
            }

            if (description.Length <= 50)
            {
                return "Description must be longer than 50 characters";
            }

            if (!flowerType.Equals("Daisies") && !flowerType.Equals("Lilies") && !flowerType.Equals("Roses"))
            {
                return "Must be either \"Daisies\", \"Lilies\" or \"Roses\"";
            }
            else
            {
                if (flowerType.Equals("Daisies"))
                {
                    flowerTypeId = 1;
                }
                else if (flowerType.Equals("Lilies"))
                {
                    flowerTypeId = 2;
                }
                else
                {
                    flowerTypeId = 3;
                }
            }

            if (!int.TryParse(price, out pricee))
            {
                return "Price must be numeric!";
            }
            else
            {
                pricee = int.Parse(price);
                if (pricee < 20 || pricee > 100)
                {
                    return "Price must be between 20 and 100 inclusively";
                }
            }

           

            ifh.insertFlower(name, fileLoc, description, flowerTypeId, pricee);
            return "";
        }
        public int CheckIfUserIsMember(string email)
        {
            bool isMember = ifh.CheckMemberEmailExist(email);
            bool isEmployee = ifh.CheckEmployeeEmailExist(email);

            if (isMember)
            {
                return 1;
            }
            else if (isEmployee)
            {
                return 0;
            }

            return -1;
        }
        public int CheckIfEmployeeIsAdministrator(string email)
        {
            MsEmployee employee = ifh.GetEmployeeData(email);
            if (employee != null)
            {
                if (employee.EmployeeEmail.Equals("admin@gmail.com"))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            return -1;
        }
    }
}