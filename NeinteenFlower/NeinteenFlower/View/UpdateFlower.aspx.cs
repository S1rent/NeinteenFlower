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
        static MsFlower mf;
        string id;
        int id_;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            id_ = int.Parse(id);

            if (!Page.IsPostBack)
            {
                mf = FlowerRepository.shared.getFlowerById(id_);
                
                if (mf == null)
                {

                }
                else
                {
                    NameTxt.Text = mf.FlowerName;
                    DescTxt.Text = mf.FlowerDescription;
                    TypeTxt.Text = mf.FlowerTypeID.ToString();
                    PriceTxt.Text = mf.FlowerPrice.ToString();
                    Picture.ImageUrl = mf.FlowerImage;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateFlowerController ufc = new UpdateFlowerController();

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