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
        HeaderFooterController controller = new HeaderFooterController();
        preOrderController poController = new preOrderController();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            var userEmail = Session["user_email"].ToString();

            int response = controller.CheckIfUserIsMember(userEmail);

            if (response == -1)
            {
                Response.Redirect("Login.aspx");
            }
            else if (response == 0)
            {
                int isAdministrator = controller.CheckIfUserIsMember(userEmail);
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

            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"]);
                MsFlower n = poController.getFlowerById(id);

                lblName.Text = n.FlowerName;
                lblType.Text = n.MsFlowerType.FlowerTypeName;
                lblDesc.Text = n.FlowerDescription;
                lblPrice.Text = n.FlowerPrice.ToString();
                Image1.ImageUrl = n.FlowerImage;
            }
        }

        protected void poBtn_Click(object sender, EventArgs e)
        {

        }
    }
}