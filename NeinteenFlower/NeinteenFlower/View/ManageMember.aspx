<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="ManageMember.aspx.cs" Inherits="NeinteenFlower.View.ManageMember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    NineteenFlower - Manage Member
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="TablePlaceHolder" runat="server">
        <table style="width:900px" border="1" id="FlowerTable">
            <tr>
                <th>Member Name</th>
                <th>Date Of Birth</th>
                <th>Gender</th>
                <th>Address</th>
                <th>Phone Number</th>
                <th>Email</th>
                <th colspan="2">Action</th>
            </tr>
    
            <% if (memberList.Count == 0)
               { %>
               <tr><td colspan="6" style="text-align: center;">No Data.</td></tr>
            <% } %>

            <asp:Repeater ID="MemberRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("MemberName") %></td>
                        <td><%# Eval("MemberDOB") %></td>
                        <td><%# Eval("MemberGender") %></td>
                        <td><%# Eval("MemberAddress") %></td>
                        <td><%# Eval("MemberPhone") %></td>
                        <td><%# Eval("MemberEmail") %></td>
                        <td>
                            <asp:Button runat="server" Text="Update" CommandArgument='<%# Eval("MemberID") %>' CommandName="UpdateMemberClicked" OnClick="UpdateMemberClickHandler" />
                        </td>
                        <td>
                            <asp:Button runat="server" Text="Delete" CommandArgument='<%# Eval("MemberID") %>' CommandName="DeleteMemberClicked" OnClick="DeleteMemberClickHandler" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </asp:PlaceHolder>
</asp:Content>
