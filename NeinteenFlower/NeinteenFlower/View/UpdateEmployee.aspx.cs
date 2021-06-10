using NeinteenFlower.Controller.Administrator;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class UpdateEmployee : System.Web.UI.Page
    {
        UpdateEmployeeController controller = new UpdateEmployeeController();
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

                    if (convertedID != -1)
                    {
                        MsEmployee employeeData = controller.GetEmployeeByID(convertedID);
                        if(employeeData == null) { Response.Redirect("ManageEmployee.aspx"); }
                        TextBoxName.Text = employeeData.EmployeeName;
                        TextBoxEmail.Text = employeeData.EmployeeEmail;
                        TextBoxPassword.Text = employeeData.EmployeePassword;
                        TextBoxPhoneNumber.Text = employeeData.EmployeePhone;
                        TextBoxAddress.Text = employeeData.EmployeeAddress;
                        TextBoxSalary.Text = employeeData.EmployeeSalary.ToString();
                        if (employeeData.EmployeeGender.Equals("Male"))
                        {
                            RadioButtonMale.Checked = true;
                        }
                        else if (employeeData.EmployeeGender.Equals("Female"))
                        {
                            RadioButtonFemale.Checked = true;
                        }
                        TextBoxCalendar.Text = this.ConvertEmployeeDOB(employeeData.EmployeeDOB);
                    }
                    else
                    {
                        Response.Redirect("ManageEmployee.aspx");
                    }
                }
            }
        }

        protected void ButtonUpdateTapped(object sender, EventArgs e)
        {
            LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
            string email = TextBoxEmail.Text.Trim().ToLower(),
                   password = TextBoxPassword.Text.Trim(),
                   name = TextBoxName.Text.Trim(),
                   birthDate = TextBoxCalendar.Text.Trim(),
                   phoneNumber = TextBoxPhoneNumber.Text.Trim(),
                   address = TextBoxAddress.Text.Trim(),
                   salary = TextBoxSalary.Text.Trim();

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

            MsEmployee currentEmployeeData = controller.GetEmployeeByID(convertedID);

            string response = controller.UpdateEmployee(
                convertedID, email, password, name, birthDate,
                isMale, isFemale, phoneNumber, address, currentEmployeeData.EmployeeEmail, salary
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

        private string ConvertEmployeeDOB(string dob)
        {
            string[] splitDOB = dob.Split('-');
            if (splitDOB.Length != 3) { return ""; }
            string day = splitDOB[0];
            string month = splitDOB[1];
            string year = splitDOB[2];

            string convertedDOB = year + "-" + month + "-" + day;
            return convertedDOB;
        }
    }
}