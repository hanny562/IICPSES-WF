<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IICPSES.ControlPanel.Lecturers.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2>Create Lecturer</h2>

            <asp:Label Text="Name" runat="server" />
            <asp:TextBox runat="server" ID="txtName" CssClass="form-control" placeholder="Full name" required="required" autofocus="autofocus" />
            <p><asp:Label runat="server" ID="lblStatus_CreateLecturer"  /></p>

            <asp:Button runat="server" ID="btnCreate" CssClass="btn btn-primary" Text="Create" OnClick="btnCreate_Click" />
        </div>
    </div>
</asp:Content>
