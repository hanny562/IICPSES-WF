<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Semesters.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
 <header>
        <h2>
                <asp:Label ID="lbSemIndex" runat="server" CssClass="page page-header" Text="Semester Index"></asp:Label></h2>
    </header>
    <body>
    <br/>
    <div>
        <asp:Button ID="btnSemLecturer" CssClass="btn btn-primary" runat="server" Text="New Semesters" />  
    </div>
    <div>
        <h3>List of Semesters</h3>
    </div>
    </body>
</asp:Content>
