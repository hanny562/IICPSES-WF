<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSurvey.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="col-sm-offset-4 col-sm-4">
        <h1>
            <asp:Label ID="lbSurveyFrontPage" runat="server" CssClass="page page-header" Text="Survey" />
        </h1>
        <div class="dropdown">
            <asp:Label ID="lbSurveyProgram" CssClass="label label-info" runat="server" Text="Program"></asp:Label><br />
            <asp:DropDownList ID="ddlSurveyProgram" CssClass="form-control" runat="server" AutoPostBack="False">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lbSurveySubject" CssClass="label label-info" runat="server" Text="Subject"></asp:Label><br />
            <asp:DropDownList ID="ddlSurveySubject" CssClass="form-control" runat="server" AutoPostBack="False">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lbSurveySemester" CssClass="label label-info" runat="server" Text="Semester"></asp:Label><br />
            <asp:DropDownList ID="ddlSurveySemester" CssClass="form-control" runat="server" AutoPostBack="False">
            </asp:DropDownList>
            <br />
        </div>
        <br />
        <div>
            <asp:Button ID="btnNext" CssClass="btn btn-primary" runat="server" Text="Next" />
        </div>
    </div>

</asp:Content>
