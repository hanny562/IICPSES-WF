<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSurvey.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>
            <asp:Label ID="lbSurveyFrontPage" runat="server" CssClass="page page-header" Text="Survey" />
        </h1>
        <br />
        <div>
            <div class="dropdown">
                <asp:Label ID="lbSurveyProgram" CssClass="label label-info" runat="server" Text="Program"></asp:Label><br />
                <asp:DropDownList ID="ddlSurveyProgram" CssClass="dropdown dropdown-header" runat="server" AutoPostBack="True">
                    <asp:ListItem>Please Select</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="lbSurveySubject" CssClass="label label-info" runat="server" Text="Subject"></asp:Label><br />
                <asp:DropDownList ID="ddlSurveySubject" CssClass="dropdown dropdown-header" runat="server" AutoPostBack="True">
                    <asp:ListItem>Please Select</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="lbSurveySemester" CssClass="label label-info" runat="server" Text="Semester"></asp:Label><br />
                <asp:DropDownList ID="ddlSurveySemester" CssClass="dropdown dropdown-header" runat="server" AutoPostBack="True">
                    <asp:ListItem>Please Select</asp:ListItem>
                </asp:DropDownList>
                <br />
            </div>
            <br />
            <div>
                <asp:Button ID="btnNext" CssClass="btn btn-primary" runat="server" Text="Next" />
            </div>
        </div>

</asp:Content>
