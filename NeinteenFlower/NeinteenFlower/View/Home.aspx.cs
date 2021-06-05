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
    public partial class Home : System.Web.UI.Page
    {
        HomeController controller = new HomeController();
        public List<MsFlower> flowerList = new List<MsFlower>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                flowerList = controller.GetFlowerList();
                FlowerRepeater.DataSource = flowerList;
                FlowerRepeater.DataBind();

                if(Session["user_email"] == null || Session["user_name"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                var userEmail = Session["user_email"].ToString();
                var userName = Session["user_name"].ToString();

                int response = controller.CheckIfUserIsMember(userEmail);

                if (response == -1)
                {
                    Session.Remove("user_name");
                    Session.Remove("user_email");

                    Response.Cookies["user_email_cookie"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["user_password_cookie"].Expires = DateTime.Now.AddDays(-1);

                    Response.Redirect("Login.aspx");
                }
                else if (response == 0)
                {
                    TablePlaceHolder.Visible = false;
                }
                else if (response == 1)
                {
                    TablePlaceHolder.Visible = true;
                }
            }
        }

        protected void PreOrderFlowerClickHandler(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.CommandName)
            {
                case "PreOrderFlowerClicked":
                    Response.Redirect("PreOrder.aspx?id=" + btn.CommandArgument.ToString());
                    break;
            }
        }

        public string FormatFlowerTypeID(string id)
        {
            if(id.Equals("1"))
            {
                return "Daisies";
            }
            else if(id.Equals("2"))
            {
                return "Lilies";
            }
            return "Roses";
        }
    }
}