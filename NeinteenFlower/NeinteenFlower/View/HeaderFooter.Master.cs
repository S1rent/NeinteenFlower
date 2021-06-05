using NeinteenFlower.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class HeaderFooter : System.Web.UI.MasterPage
    {
        HeaderFooterController controller = new HeaderFooterController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                var userEmail = Session["user_email"].ToString();
                var userName = Session["user_name"].ToString();

                LabelGreeting.Text = "Welcome, " + userName;

                int response = controller.CheckIfUserIsMember(userEmail);

                if (response == -1)
                {
                    Response.Redirect("Login.aspx");
                }
                else if (response == 0)
                {
                    int isAdministrator = controller.CheckIfEmployeeIsAdministrator(userEmail);
                    if (isAdministrator == -1)
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else if (isAdministrator == 0)
                    {
                        this.SetupEmployeeView();
                    }
                    else if (isAdministrator == 1)
                    {
                        this.SetupAdministratorView();
                    }
                }
                else if (response == 1)
                {
                    this.SetupMemberView();
                }
            }
        }

        protected void HomeClicked(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        protected void LogoutClicked(object sender, EventArgs e)
        {
            Session.Remove("user_name");
            Session.Remove("user_email");

            Response.Cookies["user_email_cookie"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["user_password_cookie"].Expires = DateTime.Now.AddDays(-1);

            Response.Redirect("Login.aspx");
        }
        protected void TransactionHistoryClicked(object sender, EventArgs e)
        {
            Response.Redirect("TransactionHistory.aspx");
        }
        protected void ManageFlowerClicked(object sender, EventArgs e)
        {
            Response.Redirect("ManageFlower.aspx");
        }
        protected void ManageMemberClicked(object sender, EventArgs e)
        {
            Response.Redirect("ManageMember.aspx");
        }
        protected void ManageEmployeeClicked(object sender, EventArgs e)
        {
            Response.Redirect("ManageEmployee.aspx");
        }

        private void SetupMemberView()
        {
            ButtonRedirectManageFlower.Visible = false;
            ButtonRedirectManageMember.Visible = false;
            ButtonRedirectManageEmployee.Visible = false;
        }

        private void SetupEmployeeView()
        {
            ButtonRedirectTransactionHistory.Visible = false;
            ButtonRedirectManageMember.Visible = false;
            ButtonRedirectManageEmployee.Visible = false;
        }
        private void SetupAdministratorView()
        {
            ButtonRedirectTransactionHistory.Visible = false;
            ButtonRedirectManageFlower.Visible = false;
        }
    }
}