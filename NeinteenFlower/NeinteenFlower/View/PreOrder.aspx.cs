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
        preOrderController poController = new preOrderController();
        protected void Page_Load(object sender, EventArgs e)
        {
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