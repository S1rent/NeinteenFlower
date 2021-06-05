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
    public partial class ManageMember : System.Web.UI.Page
    {
        ManageMemberController controller = new ManageMemberController();
        public List<MsMember> memberList = new List<MsMember>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                memberList = controller.GetMemberList();
                MemberRepeater.DataSource = memberList;
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
               Response.Redirect("Login.aspx");
            }
        }

        protected void UpdateMemberClickHandler(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.CommandName)
            {
                case "UpdateMemberClicked":
                    Response.Redirect("UpdateMember.aspx?id=" + btn.CommandArgument.ToString());
                    break;
            }
        }

        protected void DeleteMemberClickHandler(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.CommandName)
            {
                case "DeleteMemberClicked":
                    int memberID = -1;
                    try
                    {
                        memberID = Int16.Parse(btn.CommandArgument.ToString());
                    }
                    catch
                    {
                        return;
                    }

                    if(memberID != -1)
                    {
                        controller.DeleteMember(memberID);
                        Response.Redirect("ManageMember.aspx");
                    }
                    break;
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
    }
}