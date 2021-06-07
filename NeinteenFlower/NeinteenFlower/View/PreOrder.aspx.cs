using NeinteenFlower.Controller;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class PreOrder : System.Web.UI.Page
    {
        PreOrderController poController = new PreOrderController();
        protected void Page_Load(object sender, EventArgs e)
        {
            var userEmail = Session["user_email"].ToString();

            int response = poController.CheckIfUserIsMember(userEmail);

            if (response == -1)
            {
                Response.Redirect("Login.aspx");
            }
            else if (response == 0)
            {
                int isAdministrator = poController.CheckIfUserIsMember(userEmail);
                if (isAdministrator == -1)
                {

                    Response.Redirect("Login.aspx");
                }
                else if (isAdministrator == 0)
                {
                    Response.Redirect("Home.aspx");
                }
                else if (isAdministrator == 1)
                {
                    Response.Redirect("Home.aspx");
                }
            }

            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Home.aspx");
            }

            if (!IsPostBack)
            {
                string id = Request.QueryString["id"].ToString();
                int convertedID = -1;
                try
                {
                    convertedID = Int16.Parse(id);
                }
                catch
                {
                    convertedID = -1;
                }

               if(convertedID != -1)
                {
                    MsFlower n = poController.GetFlowerById(convertedID);

                    LblName.Text = n.FlowerName;
                    LblType.Text = n.MsFlowerType.FlowerTypeName;
                    LblDesc.Text = n.FlowerDescription;
                    LblPrice.Text = n.FlowerPrice.ToString();
                    Image1.ImageUrl = n.FlowerImage;
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }
        protected void poBtn_Click(object sender, EventArgs e)
        {

        }
    }
}