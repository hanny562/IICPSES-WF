<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Lecturers.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <header>
        <h2>
                <asp:Label ID="lbLecturerIndex" runat="server" CssClass="page page-header" Text="Lecturer Index"></asp:Label></h2>
    </header>
    <body>
    <br/>
    <div>
        <asp:Button ID="btnCreateLecturer" CssClass="btn btn-primary" runat="server" Text="New" OnClick="btnCreateLecturer_Click" />  
    </div>
    <div>
        <h3>List of Lecturers</h3>
    </div>
    </body>

</asp:Content>
