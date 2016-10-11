<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Semesters.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <h2><asp:Label runat="server" CssClass="page page-header" Text="Semester Index"></asp:Label></h2>
    <a href="Create.aspx" class="btn btn-primary">Create Semester</a>

    <h3>List of Semesters</h3>
    <asp:GridView runat="server" ID="gvSemesters" CssClass="table table-bordered"
        EmptyDataText="There are no semesters info at this time being."></asp:GridView>

    <h3>List of Association of Semester Subjects</h3>
    <asp:GridView runat="server" ID="gvSemesterSubjects" CssClass="table table-bordered"
        EmptyDataText="There are no semester subjects association info at this time being."></asp:GridView>
</asp:Content>
