<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="ManageEmployee.aspx.cs" Inherits="NeinteenFlower.View.ManageEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    NeinteenFlower - Manage Employee
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="InsertEmployee.aspx">Insert Employee</a>
    <asp:PlaceHolder ID="TablePlaceHolder" runat="server">
        <table style="width:900px" border="1" id="FlowerTable">
            <tr>
                <th>Employee Name</th>
                <th>Date Of Birth</th>
                <th>Gender</th>
                <th>Address</th>
                <th>Phone Number</th>
                <th>Email</th>
                <th>Salary</th>
                <th colspan="2">Action</th>
            </tr>
    
            <% if (employeeList.Count == 0)
               { %>
               <tr><td colspan="6" style="text-align: center;">No Data.</td></tr>
            <% } %>

            <asp:Repeater ID="MemberRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("EmployeeName") %></td>
                        <td><%# Eval("EmployeeDOB") %></td>
                        <td><%# Eval("EmployeeGender") %></td>
                        <td><%# Eval("EmployeeAddress") %></td>
                        <td><%# Eval("EmployeePhone") %></td>
                        <td><%# Eval("EmployeeEmail") %></td>
                        <td><%# Eval("EmployeeSalary") %></td>
                        <td>
                            <asp:Button runat="server" Text="Update" CommandArgument='<%# Eval("EmployeeID") %>' CommandName="UpdateEmployeeClicked" OnClick="UpdateEmployeeClickHandler" />
                        </td>
                        <td>
                            <asp:Button runat="server" Text="Delete" CommandArgument='<%# Eval("EmployeeID") %>' CommandName="DeleteEmployeeClicked" OnClick="DeleteEmployeeClickHandler" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </asp:PlaceHolder>
</asp:Content>
