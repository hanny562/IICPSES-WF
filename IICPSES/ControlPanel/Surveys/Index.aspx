<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Surveys.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <header>
        <h2>
            <asp:Label ID="lbSurveyIndex" runat="server" CssClass="page page-header" Text="Surve Index"></asp:Label></h2>
    </header>
    <body>
        <br />
        <div>
            <asp:Button ID="btnSurveyLecturer" CssClass="btn btn-primary" runat="server" Text="New Surveys" />
        </div>
        <div>
            <h3>List of Surveys</h3>
        </div>
    </body>
</asp:Content>
