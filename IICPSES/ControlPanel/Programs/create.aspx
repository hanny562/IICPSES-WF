<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IICPSES.ControlPanel.Programs.create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2><asp:Label ID="lbProgramTitle" runat="server" CssClass="page page-header" Text="Create Programs"></asp:Label></h2>

            <asp:Label Text="Program Name" CssClass="label label-info" runat="server" />
            <asp:TextBox runat="server" ID="txtProgramName" CssClass="form-control" placeholder="Program Name" required="required" autofocus="autofocus" />

            <asp:Label Text="Program Code" CssClass="label label-info" runat="server" />
            <asp:TextBox runat="server" ID="txtProgramCode" CssClass="form-control" placeholder="Program Code" required="required" autofocus="autofocus" />

            <asp:Label Text="School" runat="server" CssClass="label label-info" />
            <asp:DropDownList runat="server" ID="ddlSchools" CssClass="form-control"></asp:DropDownList>

            <p><asp:Label runat="server" ID="lblStatus_CreateProgram" /></p>

            <asp:Button runat="server" ID="btnCreateProgram" CssClass="btn btn-primary" Text="Create" OnClick="btnCreateProgram_Click" />
        </div>
    </div>
</asp:Content>
