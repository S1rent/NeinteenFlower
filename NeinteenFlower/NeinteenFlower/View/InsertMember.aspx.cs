using NeinteenFlower.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class InsertMember : System.Web.UI.Page
    {
        InsertMemberController controller = new InsertMemberController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user_email"] == null || Session["user_name"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                var userEmail = Session["user_email"].ToString();

                bool response = controller.CheckIfUserIsAdministrator(userEmail);

                if (!response)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void ButtonInsertTapped(object sender, EventArgs e)
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

            string response = controller.InsertMember(
                email, password, name, birthDate,
                isMale, isFemale, phoneNumber, address
            );

            if (response.Equals(""))
            {
                LabelErrorMessage.ForeColor = System.Drawing.Color.Green;
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.Text = "Successfully created account.";
            }
            else
            {
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.Text = response;
            }
        }
    }
}