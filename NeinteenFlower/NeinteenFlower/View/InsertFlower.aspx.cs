using NeinteenFlower.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class InsertFlower : System.Web.UI.Page
    {
        InsertFlowerController ifc = new InsertFlowerController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_email"] == null || Session["user_name"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            var userEmail = Session["user_email"].ToString();

            int response = ifc.CheckIfUserIsMember(userEmail);

            if (response == -1)
            {
                Response.Redirect("Login.aspx");
            }
            else if (response == 0)
            {
                int isAdministrator = ifc.CheckIfEmployeeIsAdministrator(userEmail);
                if (isAdministrator == -1)
                {
                    Response.Redirect("Login.aspx");
                }

                else if (isAdministrator == 1)
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else if (response == 1)
            {
                Response.Redirect("Home.aspx");
            }

        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;
            string desc = descTxt.Text;
            string type = typeTxt.Text;
            string price = priceTxt.Text;
            var file = FileUpload1.PostedFile;
            string msg = ifc.InsertFlower(name, file, desc, type, price);

            if (msg == "")
            {
                lblMsg.Text = "Insert Flower Success";
            }
            else
            {
                lblMsg.Text = msg;
            }

        }
    }
}