using NeinteenFlower.Controller.Member;
using NeinteenFlower.Dataset;
using NeinteenFlower.Model;
using NeinteenFlower.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        TransactionHistoryController controller = new TransactionHistoryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user_email"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!controller.CheckIfUserIsMember(Session["user_email"].ToString()))
            {
                Response.Redirect("Home.aspx");
            }

            NeinteenFlowerReport report = new NeinteenFlowerReport();
            CrystalReportViewer1.ReportSource = report;

            NeinteenFlowerDataset data = getData(controller.GetMemberTransactionHeaderList(Session["user_email"].ToString()));
            report.SetDataSource(data);
        }

        private NeinteenFlowerDataset getData(List<TrHeader> transactionList)
        {
            NeinteenFlowerDataset data = new NeinteenFlowerDataset();

            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;

            for(int i=0;i<transactionList.Count;i++)
            {
                TrHeader headerData = transactionList[i];
                var header = headerTable.NewRow();

                header["TransactionID"] = headerData.TransactionID;
                header["MemberID"] = headerData.MemberID;
                header["TransactionDate"] = headerData.TransactionDate;
                headerTable.Rows.Add(header);

                foreach(TrDetail detailData in headerData.TrDetails)
                {
                    var detail = detailTable.NewRow();

                    detail["TransactionID"] = detailData.TransactionID;
                    detail["FlowerID"] = detailData.FlowerID;
                    detail["Quantity"] = detailData.Quantity;
                    detail["SubTotal"] = controller.CountSubTotal(detailData.FlowerID, detailData.Quantity);
                    detail["GrandTotal"] = controller.CountGrandTotal(headerData);

                    detailTable.Rows.Add(detail);
                }
            }

            return data;
        }
    }
}