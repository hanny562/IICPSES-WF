<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Surveys.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <header>
        <h2>
            <asp:Label ID="lbSurveyIndex" runat="server" CssClass="page page-header" Text="Survey Index"></asp:Label></h2>
    </header>
        <br />
            <a href="Questions/Create.aspx" class="btn btn-primary">Create New Question</a>

            <h3>List of Survey Questions</h3>
            <asp:GridView runat="server" ID="gvSurveyQuestions" CssClass="table table-bordered"
        EmptyDataText="There are no subjects info at this time being."></asp:GridView>
</asp:Content>
