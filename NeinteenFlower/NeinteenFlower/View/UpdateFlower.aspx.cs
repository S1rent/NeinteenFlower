using NeinteenFlower.Controller;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class UpdateFlower : System.Web.UI.Page
    {
        UpdateFlowerController ufc = new UpdateFlowerController();
        string id;
        int id_ = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            var queryID = Request.QueryString["id"];
            var queryEmail = Session["user_email"];
            if (queryID == null || queryEmail == null)
            {
                Response.Redirect("Home.aspx");
            }

            id = queryID.ToString();
            try
            {
                id_ = int.Parse(id);
            }
            catch
            {
                Response.Redirect("ManageFlower.aspx");
            }

            if(!ufc.CheckIfUserIsEmployee(queryEmail.ToString()))
            {
                Response.Redirect("ManageFlower.aspx");
            }

            if (!Page.IsPostBack)
            {
                MsFlower mf = ufc.GetFlowerByID(id_);
                
                if (mf == null || mf.IsDeleted == 1)
                {
                    Response.Redirect("ManageFlower.aspx");
                }
                else
                {
                    NameTxt.Text = mf.FlowerName;
                    DescTxt.Text = mf.FlowerDescription;
                    PriceTxt.Text = mf.FlowerPrice.ToString();
                    Picture.ImageUrl = mf.FlowerImage;

                    if (mf.FlowerTypeID == 1)
                    {
                        TypeTxt.Text = "Daisies";
                    }
                    else if (mf.FlowerTypeID == 2)
                    {
                        TypeTxt.Text = "Lilies";
                    }
                    else
                    {
                        TypeTxt.Text = "Roses";
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = NameTxt.Text;
            string desc = DescTxt.Text;
            string type = TypeTxt.Text;
            string price = PriceTxt.Text;
            var file = FileUpload1.PostedFile;
            string msg = ufc.UpdateFlower(id, name, file, desc, type, price);

            if (msg == "")
            {
                lblMsg.Text = "Update Flower Success";
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = msg;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Response.Redirect("./ManageFlower.aspx");
        }
    }
}