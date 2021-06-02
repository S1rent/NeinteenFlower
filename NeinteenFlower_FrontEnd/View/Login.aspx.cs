﻿using NeinteenFlower_FrontEnd.Controller;
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

        }

        protected void ButtonLoginTapped(object sender, EventArgs e)
        {
            LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
            string email = TextBoxEmail.Text.Trim(),
                   password = TextBoxPassword.Text.Trim();
            string response = controller.Login(email, password);

            if (response.Equals(""))
            {
                LabelErrorMessage.Visible = false;
            }
            else
            {
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.Text = response;
            }
        }
    }
}