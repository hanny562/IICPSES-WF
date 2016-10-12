<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Lecturers.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <h2>Lecturer Index</h2>
    <a href="Create.aspx" class="btn btn-primary">Create New Lecturer</a>

    <h3>List of Lecturers</h3>
    <asp:GridView ID="gvLecturers" runat="server" CssClass="table table-bordered"
         ShowHeader="true" ShowHeaderWhenEmpty="true" EmptyDataText="There are no lecturers information at the time being."></asp:GridView>


</asp:Content>
