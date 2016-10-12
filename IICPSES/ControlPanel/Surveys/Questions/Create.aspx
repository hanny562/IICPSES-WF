<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IICPSES.ControlPanel.Surveys.Questions.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2>Create Survey Question</h2>

            <asp:Label Text="Question Title" CssClass="label label-info" runat="server" />
            <asp:TextBox runat="server" ID="txtQuestionTitle" CssClass="form-control" placeholder="Question Title" required="required" />

            <asp:Label Text="Question Description" CssClass="label label-info" runat="server" />
            <asp:TextBox runat="server" ID="txtQuestionDescription" CssClass="form-control" placeholder="Question Description" required="required" />

            <asp:Label Text="Question Type" CssClass="label label-info" runat="server" />
            <asp:DropDownList runat="server" ID="ddlQuestionType" CssClass="form-control">
                <asp:ListItem Text="Plain Text" Value="1" />
                <asp:ListItem Text="Number" Value="2" />
                <asp:ListItem Text="True/False" Value="3" />
            </asp:DropDownList>

            <asp:Button Text="Create" runat="server" ID="btnCreateSurveyQuestion" CssClass="btn btn-primary" OnClick="btnCreateSurveyQuestion_Click" />
            <asp:Label runat="server" ID="lblQuestion_Status" />
        </div>
    </div>
</asp:Content>
