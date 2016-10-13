<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Programs.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <h2>Program Index</h2>
    

    <h3>List of Programs</h3>
    <a href="Create.aspx" class="btn btn-primary">Create Program</a>
    <asp:GridView runat="server" ID="gvPrograms" CssClass="table table-bordered"
        EmptyDataText="There are no programs information at the time being."></asp:GridView>
   
    <h3>List of Subjects Associated to Program</h3>
    <a href="Manage/Subject.aspx" class="btn btn-primary">Create Association</a>
    <asp:GridView runat="server" ID="gvProgramSubjects" CssClass="table table-bordered"
        EmptyDataText="There are no program subjects information at the time being."></asp:GridView>
</asp:Content>
