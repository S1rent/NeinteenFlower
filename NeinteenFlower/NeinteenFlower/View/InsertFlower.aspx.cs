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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            InsertFlowerController ifc = new InsertFlowerController();

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