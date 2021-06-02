using NeinteenFlower.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        ForgotPasswordController controller = new ForgotPasswordController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string captcha = controller.GenerateCaptcha();
                LabelCaptcha.Text = "Captcha: " + captcha;
                LabelCaptchaHelper.Text = captcha;
            }
        }

        protected void ButtonResetTapped(object sender, EventArgs e)
        {
            LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
            string email = TextBoxEmail.Text.Trim(),
                   password = TextBoxPassword.Text.Trim(),
                   captcha = LabelCaptchaHelper.Text.Trim();
            string response = controller.ForgotPassword(email, password, captcha);

            if (response.Equals(""))
            {
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.ForeColor = System.Drawing.Color.Green;
                LabelErrorMessage.Text = "Successfully update password";

                Response.Redirect("Login.aspx");
            }
            else
            {
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.Text = response;
            }
        }
    }
}