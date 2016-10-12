<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Report.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <header>
        <div style="text-align: left;">
            <h2>
                <asp:Label ID="lbReportIndex" runat="server" CssClass="page page-header" Text="Evaluation Report"></asp:Label></h2>
        </div>
    </header>
    <br />
    <body>
        <div class="container">
            <div class="dropdown">
                <asp:Label ID="lbLecturerReport" CssClass="label label-info" runat="server" Text="Lecturer"></asp:Label><br />
                <asp:DropDownList ID="ddlLecturerReport" CssClass="dropdown dropdown-header" runat="server">
                    <asp:ListItem>Please Select</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lbSubjectReport" CssClass="label label-info" runat="server" Text="Subject"></asp:Label><br />
                <asp:DropDownList ID="ddlSubjectReport" CssClass="dropdown dropdown-header" runat="server">
                    <asp:ListItem>Please Select</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
               
            </div>
            <br />
            <div>
                <asp:Button ID="btnConfirm" CssClass="btn btn-primary" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
            </div>
        </div>
    </body>

</asp:Content>
