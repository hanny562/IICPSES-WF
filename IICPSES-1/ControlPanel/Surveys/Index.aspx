<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Surveys.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <h2>Survey Index</h2>

    <h3>List of Survey Questions</h3>
    <a href="Questions/Create.aspx" class="btn btn-primary">Create New Survey Question</a>
    <asp:GridView runat="server" ID="gvSurveyQuestions" CssClass="table table-bordered"
        EmptyDataText="There are no survey questions info at this time being.">
    </asp:GridView>

    <asp:Label ID="dummy" runat="server" />
</asp:Content>
