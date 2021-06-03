using NeinteenFlower_FrontEnd.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower_FrontEnd.View
{
    public partial class Login : System.Web.UI.Page
    {
        LoginController controller = new LoginController();
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxPassword.Attributes["type"] = "password";
            if (Session["user_email"] != null)
            {
                Response.Redirect("Home.aspx");
            }

            var userEmailCookie = Request.Cookies["user_email_cookie"];
            var userPasswordCookie = Request.Cookies["user_password_cookie"];
            if (userEmailCookie != null && userPasswordCookie != null)
            {
                TextBoxEmail.Text = userEmailCookie.Value;
                TextBoxPassword.Text = userPasswordCookie.Value;
            }
        }

        protected void ButtonLoginTapped(object sender, EventArgs e)
        {
            LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
            string email = TextBoxEmail.Text.Trim(),
                   password = TextBoxPassword.Text.Trim();

            bool isRememberMeChecked = CheckBoxRememberMe.Checked;

            string response = controller.Login(email, password);

            if (response.Equals(""))
            {
                LabelErrorMessage.Visible = false;
                this.SetupSession(email);

                if(isRememberMeChecked)
                {
                    this.SetupCookie(email, password);
                }

                Response.Redirect("Home.aspx");
            }
            else
            {
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.Text = response;
            }
        }

        private void SetupSession(string email)
        {
            Session["user_email"] = email;
            Session["user_name"] = controller.GetUsername(email);
        }

        private void SetupCookie(string email, string password)
        {
            HttpCookie emailCookie = new HttpCookie("user_email_cookie");
            emailCookie.Value = email;
            emailCookie.Expires = DateTime.Now.AddDays(1);

            HttpCookie passwordCookie = new HttpCookie("user_password_cookie");
            passwordCookie.Value = password;
            passwordCookie.Expires = DateTime.Now.AddDays(1);

            Response.Cookies.Add(emailCookie);
            Response.Cookies.Add(passwordCookie);
        }
    }
}