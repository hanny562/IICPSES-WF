<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IICPSES.ControlPanel.Subjects.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2><asp:Label runat="server" CssClass="page page-header" Text="Create Subject"></asp:Label></h2>

            <asp:Label Text="Subject Name" CssClass="label label-info" runat="server" />
            <asp:TextBox runat="server" ID="txtSubjectName" CssClass="form-control" placeholder="Subject Name" required="required" autofocus="autofocus" />

            <asp:Label Text="Subject Code" CssClass="label label-info" runat="server" />
            <asp:TextBox runat="server" ID="txtSubjectCode" CssClass="form-control" placeholder="Subject Code" required="required" />

            <p><asp:Label runat="server" ID="lblStatus_CreateSubject" /></p>

            <asp:Button runat="server" ID="btnCreateSubject" CssClass="btn btn-primary" Text="Create" OnClick="btnCreateSubject_Click"/>
        </div>
    </div>
</asp:Content>
