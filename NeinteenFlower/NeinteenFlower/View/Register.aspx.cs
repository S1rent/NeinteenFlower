using NeinteenFlower.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class Register : System.Web.UI.Page
    {
        RegisterController controller = new RegisterController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_email"] != null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void ButtonRegisterTapped(object sender, EventArgs e)
        {
            LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
            string email = TextBoxEmail.Text.Trim().ToLower(),
                   password = TextBoxPassword.Text.Trim(),
                   name = TextBoxName.Text.Trim(),
                   birthDate = TextBoxCalendar.Text.Trim(),
                   phoneNumber = TextBoxPhoneNumber.Text.Trim(),
                   address = TextBoxAddress.Text.Trim();

            bool isMale = RadioButtonMale.Checked,
                 isFemale = RadioButtonFemale.Checked;

            string response = controller.Register(
                email, password, name, birthDate, 
                isMale, isFemale, phoneNumber, address
            );

            if (response.Equals(""))
            {
                LabelErrorMessage.ForeColor = System.Drawing.Color.Green;
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.Text = "Successfully created account.";

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