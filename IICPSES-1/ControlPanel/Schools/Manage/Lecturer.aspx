<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lecturer.aspx.cs" Inherits="IICPSES.ControlPanel.Schools.Manage.Lecturer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2>Manage School Lecturers</h2>

            <asp:Label Text="School" CssClass="label label-info" runat="server" />
            <asp:DropDownList runat="server" ID="ddlSchool" CssClass="form-control"></asp:DropDownList>

            <asp:Label Text="Lecturer" CssClass="label label-info" runat="server" />
            <asp:CheckBoxList runat="server" ID="cblLecturers" CssClass="form-control"></asp:CheckBoxList>

            <p>Click <strong>Associate</strong> to start associating the selected lecturers to the selected school.</p>
            <asp:Button Text="Associate" runat="server" ID="btnAssociateSchoolLecturers" CssClass="btn btn-primary" OnClick="btnAssociateSchoolLecturers_Click" />

            <asp:Label runat="server" ID="lblSchoolLecturer_Status" />
        </div>
    </div>
</asp:Content>
