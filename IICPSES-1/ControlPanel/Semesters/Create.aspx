<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IICPSES.ControlPanel.Semesters.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2><asp:Label runat="server" CssClass="page page-header" Text="Create School"></asp:Label></h2>

            <asp:Label Text="Semester Name" CssClass="label label-info" runat="server" />
            <asp:TextBox runat="server" ID="txtSemesterName" CssClass="form-control" placeholder="Semester Name" required="required" autofocus="autofocus" />

            <asp:Label Text="Month" CssClass="label label-info" runat="server" />
            <asp:DropDownList runat="server" ID="ddlSemesterMonth" CssClass="form-control">
                <asp:ListItem Text="January" Value="1" />
                <asp:ListItem Text="February" Value="2" />
                <asp:ListItem Text="March" Value="3" />
                <asp:ListItem Text="April" Value="4" />
                <asp:ListItem Text="May" Value="5" />
                <asp:ListItem Text="June" Value="6" />
                <asp:ListItem Text="July" Value="7" />
                <asp:ListItem Text="August" Value="8" />
                <asp:ListItem Text="September" Value="9" />
                <asp:ListItem Text="October" Value="10" />
                <asp:ListItem Text="November" Value="11" />
                <asp:ListItem Text="December" Value="12" />
            </asp:DropDownList>

            <asp:Label Text="Year" CssClass="label label-info" runat="server" />
            <asp:DropDownList runat="server" ID="ddlSemesterYear" CssClass="form-control">
                <asp:ListItem Text="2016" Value="2016" />
                <asp:ListItem Text="2017" Value="2017" />
                <asp:ListItem Text="2018" Value="2018" />
                <asp:ListItem Text="2019" Value="2019" />
                <asp:ListItem Text="2020" Value="2020" />
            </asp:DropDownList>

            <p><asp:Label runat="server" ID="lblStatus_CreateSemester" /></p>

            <asp:Button runat="server" ID="btnCreateSemester" CssClass="btn btn-primary" Text="Create" OnClick="btnCreateSemester_Click"/>
        </div>
    </div>
</asp:Content>
