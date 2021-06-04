﻿using NeinteenFlower.Controller;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class ManageFlower : System.Web.UI.Page
    {
        HomeController controller = new HomeController();
        HeaderFooterController hfcontroller = new HeaderFooterController();
        DeleteFlowerController dfController = new DeleteFlowerController();
        public List<MsFlower> flowerList = new List<MsFlower>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                flowerList = controller.GetFlowerList();
                FlowerRepeater.DataSource = flowerList;
                FlowerRepeater.DataBind();
            }

            if (Session["user_email"] == null || Session["user_name"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            var userEmail = Session["user_email"].ToString();

            int response = hfcontroller.CheckIfUserIsMember(userEmail);

            if (response == -1)
            {
                Response.Redirect("Login.aspx");
            }
            else if (response == 0)
            {
                int isAdministrator = hfcontroller.CheckIfEmployeeIsAdministrator(userEmail);
                if (isAdministrator == -1)
                {
                    Response.Redirect("Login.aspx");
                }
               
                else if (isAdministrator == 1)
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else if (response == 1)
            {
                Response.Redirect("Home.aspx");
            }
        }
        public string FormatFlowerTypeID(string id)
        {
            if (id.Equals("1"))
            {
                return "Daisies";
            }
            else if (id.Equals("2"))
            {
                return "Lilies";
            }
            return "Roses";
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int id = int.Parse(btn.CommandArgument.ToString());
            dfController.deleteFlowerById(id);
            lblDel.Visible = true;
            Response.Redirect("./ManageFlower.aspx");
        }

        protected void btnUp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Response.Redirect("./UpdateFlower.aspx?id=" + btn.CommandArgument.ToString());
        }
    }
}