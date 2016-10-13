<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subject.aspx.cs" Inherits="IICPSES.ControlPanel.Programs.Manage.Subject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2>Manage Program Subjects</h2>
            <p>Select a program, and select the lists of subjects to be associated with.</p>

            <asp:Label Text="Programs" CssClass="label label-info" runat="server" />
            <asp:DropDownList runat="server" ID="ddlProgram" CssClass="form-control"></asp:DropDownList>

            <asp:Label Text="Subject List" CssClass="label label-info" runat="server" />
            <asp:CheckBoxList ID="cblSubjects" runat="server"></asp:CheckBoxList>

            <p>Click <strong>Associate</strong> to start associating the selected subjects to the selected program.</p>
            <asp:Button Text="Associate" runat="server" ID="btnAssociateProgramSubjects" CssClass="btn btn-primary" OnClick="btnAssociateProgramSubjects_Click" />

            <asp:Label runat="server" ID="lblProgramSubject_Status" />
        </div>
    </div>
</asp:Content>
