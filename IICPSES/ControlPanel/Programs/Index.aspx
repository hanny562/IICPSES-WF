<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Programs.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <header>
        <h2>
                <asp:Label ID="lbProgramIndex" runat="server" CssClass="page page-header" Text="Program Index"></asp:Label></h2>
    </header>
    <body>
    <br/>
    <div>
        <asp:Button ID="btnCreateProgram" CssClass="btn btn-primary" runat="server" Text="New Program" />  
    </div>
    <div>
        <h3>List of Programs</h3>
    </div>
    </body>
</asp:Content>
