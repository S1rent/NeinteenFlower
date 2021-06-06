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
    public partial class ManageEmployee : System.Web.UI.Page
    {
        ManageEmployeeController controller = new ManageEmployeeController();
        public List<MsEmployee> employeeList = new List<MsEmployee>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                employeeList = controller.GetEmployeeList();
                MemberRepeater.DataSource = employeeList;
                MemberRepeater.DataBind();
            }

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
        }

        protected void UpdateEmployeeClickHandler(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.CommandName)
            {
                case "UpdateEmployeeClicked":
                    Response.Redirect("UpdateEmployee.aspx?id=" + btn.CommandArgument.ToString());
                    break;
            }
        }

        protected void DeleteEmployeeClickHandler(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.CommandName)
            {
                case "DeleteEmployeeClicked":
                    int employeeID = -1;
                    try
                    {
                        employeeID = Int16.Parse(btn.CommandArgument.ToString());
                    }
                    catch
                    {
                        return;
                    }

                    if (employeeID != -1)
                    {
                        controller.DeleteEmployee(employeeID);
                        Response.Redirect("ManageEmployee.aspx");
                    }
                    break;
            }
        }
    }
}