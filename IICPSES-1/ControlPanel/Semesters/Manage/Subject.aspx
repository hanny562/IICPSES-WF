<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subject.aspx.cs" Inherits="IICPSES.ControlPanel.Semesters.Manage.Subject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <h2>Manage Semester Subjects</h2>
            <p>Create a profile to be used in surveys.</p>

            <asp:Label Text="Semester" CssClass="label label-info" runat="server" />
            <asp:DropDownList runat="server" ID="ddlSemester" CssClass="form-control"></asp:DropDownList>

            <asp:Label Text="School Lecturer" CssClass="label label-info" runat="server" />
            <asp:DropDownList runat="server" ID="ddlSchoolLecturers" CssClass="form-control"
                OnSelectedIndexChanged="ddlSchoolLecturers_SelectedIndexChanged" OnDataBound="ddlSchoolLecturers_DataBound" 
                AutoPostBack="true">
            </asp:DropDownList>

            <asp:Label Text="Program Subject" CssClass="label label-info" runat="server" />
            <asp:DropDownList runat="server" ID="ddlProgramSubject" CssClass="form-control"></asp:DropDownList>

            <p>Create <strong>Associate</strong> to create the survey profile based on settings above.</p>

            <p><asp:Label runat="server" ID="lblSemesterSubject_Status" /></p>

            <asp:Button Text="Create" runat="server" ID="btnCreateSemesterSubject" CssClass="btn btn-primary" OnClick="btnCreateSemesterSubject_Click" />
            
        </div>
    </div>

</asp:Content>
