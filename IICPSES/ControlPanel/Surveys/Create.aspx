<%@ Page Title="" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IICPSES.ControlPanel.Surveys.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <a href="Index.aspx" class="btn btn-default">&lt; Back to Survey</a>

            <h2><asp:Label ID="lbSurveyTitle" runat="server" CssClass="page page-header" Text="Create Question"></asp:Label></h2>

            <asp:Label Text="Question" CssClass="label label-info" runat="server" />
            <asp:TextBox runat="server" ID="txtQuestion" CssClass="form-control" placeholder="Survey Question" required="required" autofocus="autofocus" />
           
            <p><asp:Label runat="server" ID="lblStatus_CreateQuestion" /></p>

            <asp:Button runat="server" ID="btnCreate" CssClass="btn btn-primary" Text="Create" OnClick="btnCreate_Click" />
        </div>
    </div>
</asp:Content>
