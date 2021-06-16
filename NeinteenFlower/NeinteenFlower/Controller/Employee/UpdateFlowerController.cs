using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class UpdateFlowerController
    {
        UpdateFlowerHandler ufh = new UpdateFlowerHandler();
        static MsFlower mf;
        static int flowerID;

        public bool CheckIfUserIsEmployee(string email)
        {
            if(email == null)
            {
                return false;
            }
            List<MsEmployee> employeeList = ufh.GetEmployeeByEmail(email);
            if(employeeList.Count == 0 || email.ToLower().Equals("admin@gmail.com"))
            {
                return false;
            }
            return true;
        }

        public MsFlower GetFlowerByID(int id)
        {
            return ufh.GetFlowerByID(id);
        }


        public string UpdateFlower(string id, string name, HttpPostedFile image, string description, String flowerType, String price)
        {
            int pricee = 0;
            int flowerTypeId = 0;
            flowerID = int.Parse(id);
            mf = FlowerRepository.shared.GetFlowerById(flowerID);
            string fileLoc = mf.FlowerImage;

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

            if (System.IO.Path.GetExtension(image.FileName).Equals(""))
            {

            }
            else if (!System.IO.Path.GetExtension(image.FileName).Equals(".jpg"))
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
                    return "between 20 and 100 inclusively";
                }
            }
            var tempIsDeleted = -1;
            if(mf.IsDeleted == null)
            {
                tempIsDeleted = 0;
            }
            else
            {
                tempIsDeleted = (int)mf.IsDeleted;
            }
            ufh.updateFlower(flowerID, name, fileLoc, description, flowerTypeId, pricee, tempIsDeleted);
            return "";
        }
    }
}