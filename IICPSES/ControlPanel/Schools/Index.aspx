<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Schools.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <header>
        <h2>
            <asp:Label ID="lbSchIndex" runat="server" CssClass="page page-header" Text="School Index"></asp:Label></h2>
    </header>
    <body>
        <br />
        <div>
            <asp:Button ID="btnCreateSch" CssClass="btn btn-primary" runat="server" Text="New School" />
        </div>
        <div>
            <h3>List of Schools</h3>
        </div>
    </body>
</asp:Content>
