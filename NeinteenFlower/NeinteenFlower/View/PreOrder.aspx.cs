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
    public partial class PreOrder : System.Web.UI.Page
    {
        PreOrderController poController = new PreOrderController();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
                if (Session["user_email"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                var userEmail = Session["user_email"].ToString();
                int response = poController.CheckIfUserIsMember(userEmail);

                if (response == -1)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    if (Request.QueryString["id"] == null)
                    {
                        Response.Redirect("Home.aspx");
                    }
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
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        MsFlower flower = poController.GetFlowerById(convertedID);
                        if (flower == null)
                        {
                            Response.Redirect("Home.aspx");
                        }

                        LblName.Text = flower.FlowerName;
                        LblType.Text = flower.MsFlowerType.FlowerTypeName;
                        LblDesc.Text = flower.FlowerDescription;
                        LblPrice.Text = flower.FlowerPrice.ToString();
                        Image1.ImageUrl = flower.FlowerImage;
                    }
                }
            }
        }
        protected void poBtn_Click(object sender, EventArgs e)
        {
            string quantity = QuantityTxt.Text.Trim();
            string id = Request.QueryString["id"].ToString();
            string userEmail = Session["user_email"].ToString();

            string response = poController.PreOrder(quantity, id, userEmail);
            if(response == "")
            {
                LabelErrorMessage.ForeColor = System.Drawing.Color.Green;
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.Text = "Successfully place order";
            }
            else
            {
                if(response.Equals("err/invalid_id"))
                {
                    Response.Redirect("Home.aspx");
                }
                else if(response.Equals("err/invalid_member"))
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
                    LabelErrorMessage.Visible = true;
                    LabelErrorMessage.Text = response;
                }
            }
        }
    }
}