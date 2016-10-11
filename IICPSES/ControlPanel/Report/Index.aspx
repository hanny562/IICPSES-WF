<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Report.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <header>
        <div style="text-align: center;">
            <h2>Evaluation Result</h2>
        </div>
    </header>
    <body>
        <div class="container">
            <asp:Label ID="lbProgramReport" runat="server" Text="Program"></asp:Label><br />
            <asp:DropDownList ID="ddlProgramReport" runat="server">
                <asp:ListItem>Please Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="lbSubjectReport" runat="server" Text="Subject"></asp:Label><br />
            <asp:DropDownList ID="ddlSubjectReport" runat="server">
                <asp:ListItem>Please Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="lbSemester" runat="server" Text="Semester"></asp:Label><br />
            <asp:DropDownList ID="ddlSemesterReport" runat="server">
                <asp:ListItem>Please Select</asp:ListItem>
            </asp:DropDownList>
        </div>
    </body>

</asp:Content>
