<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="IICPSES_1.ControlPanel.Lecturers.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <a href="Index.aspx" class="btn btn-default">&laquo; Back to Lecturer</a>

            <h2>Edit Lecturer</h2>

            <asp:Label Text="Name" CssClass="label label-info" runat="server" />
            <asp:TextBox runat="server" ID="txtName" CssClass="form-control" placeholder="Full name" required="required" autofocus="autofocus" />
           
            <asp:Button runat="server" ID="btnEdit" CssClass="btn btn-primary" Text="Edit" OnClick="btnEdit_Click"/>

            <p><asp:Label runat="server" ID="lblStatus_EditLecturer" /></p>
        </div>
    </div>

    <asp:HiddenField ID="hfLecturerId" runat="server" />
</asp:Content>
