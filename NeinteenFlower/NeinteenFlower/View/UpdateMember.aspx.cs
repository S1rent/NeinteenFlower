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
    public partial class UpdateMember : System.Web.UI.Page
    {
        UpdateMemberController controller = new UpdateMemberController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBoxPassword.Attributes["type"] = "password";
                if (Session["user_email"] == null || Session["user_name"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                var userEmail = Session["user_email"].ToString();

                bool response = controller.CheckIfUserIsAdministrator(userEmail);

                if (!response)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    string id = Request.QueryString["id"].ToString();
                    int convertedID = -1;
                    try
                    {
                        convertedID = Int16.Parse(id);
                    }
                    catch
                    {
                        convertedID = -1;
                    }

                    if(convertedID != -1)
                    {
                        MsMember memberData = controller.GetMemberByID(convertedID);
                        if (memberData == null) { Response.Redirect("ManageMember.aspx"); }
                        TextBoxName.Text = memberData.MemberName;
                        TextBoxEmail.Text = memberData.MemberEmail;
                        TextBoxPassword.Text = memberData.MemberPassword;
                        TextBoxPhoneNumber.Text = memberData.MemberPhone;
                        TextBoxAddress.Text = memberData.MemberAddress;
                        if(memberData.MemberGender.Equals("Male"))
                        {
                            RadioButtonMale.Checked = true;
                        }
                        else if(memberData.MemberGender.Equals("Female"))
                        {
                            RadioButtonFemale.Checked = true;
                        }
                        TextBoxCalendar.Text = this.ConvertMemberDOB(memberData.MemberDOB);
                    }
                    else
                    {
                        Response.Redirect("ManageMember.aspx");
                    }
                }
            }
        }

        protected void ButtonUpdateTapped(object sender, EventArgs e)
        {
            LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
            string email = TextBoxEmail.Text.Trim(),
                   password = TextBoxPassword.Text.Trim(),
                   name = TextBoxName.Text.Trim(),
                   birthDate = TextBoxCalendar.Text.Trim(),
                   phoneNumber = TextBoxPhoneNumber.Text.Trim(),
                   address = TextBoxAddress.Text.Trim();

            bool isMale = RadioButtonMale.Checked,
                 isFemale = RadioButtonFemale.Checked;

            string id = Request.QueryString["id"].ToString();
            int convertedID = -1;
            try
            {
                convertedID = Int16.Parse(id);
            }
            catch
            {
                convertedID = -1;
            }

            if (convertedID == -1)
            {
                return;
            }

            MsMember currentMemberData = controller.GetMemberByID(convertedID);

            string response = controller.UpdateMember(
                convertedID, email, password, name, birthDate,
                isMale, isFemale, phoneNumber, address, currentMemberData.MemberEmail
            );

            if (response.Equals(""))
            {
                LabelErrorMessage.ForeColor = System.Drawing.Color.Green;
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.Text = "Successfully update account.";
            }
            else
            {
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.Text = response;
            }
        }

        private string ConvertMemberDOB(string dob)
        {
            string[] splitDOB = dob.Split('-');
            if(splitDOB.Length != 3) { return "";  }
            string day = splitDOB[0];
            string month = splitDOB[1];
            string year = splitDOB[2];

            string convertedDOB = year + "-" + month + "-" + day;
            return convertedDOB;
        }
    }
}