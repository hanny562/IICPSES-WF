<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IICPSES.ControlPanel.Schools.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2><asp:Label ID="lbSchoolTitle" runat="server" CssClass="page page-header" Text="Create School"></asp:Label></h2>

            <asp:Label Text="School Name" CssClass="label label-info" runat="server" />
            <asp:TextBox runat="server" ID="txtSchoolName" CssClass="form-control" placeholder="School Name" required="required" autofocus="autofocus" />

            <asp:Label Text="School Code" CssClass="label label-info" runat="server" />
            <asp:TextBox runat="server" ID="txtSchoolCode" CssClass="form-control" placeholder="School Code" required="required" autofocus="autofocus" />

            <p><asp:Label runat="server" ID="lblStatus_CreateSchool" /></p>

            <asp:Button runat="server" ID="btnCreateSchool" CssClass="btn btn-primary" Text="Create" OnClick="btnCreateSchool_Click" />
        </div>
    </div>
</asp:Content>
