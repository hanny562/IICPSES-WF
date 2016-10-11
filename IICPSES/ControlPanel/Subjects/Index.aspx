<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Subjects.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
 <header>
        <h2><asp:Label ID="lbSubjectIndex" runat="server" CssClass="page page-header" Text="Subject Index"></asp:Label></h2>
    </header>
    <body>
    <br/>
    <div>
        <asp:Button ID="btnCreateSubject" CssClass="btn btn-primary" runat="server" Text="New Sbujects" />  
    </div>
    <div>
        <h3>List of Subjects</h3>
    </div>
    </body>
</asp:Content>
