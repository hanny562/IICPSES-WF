<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProgramSubject.aspx.cs" Inherits="IICPSES_1.ControlPanel.Lecturers.Manage.ProgramSubject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-sm-12">
                    <h2>Manage Association between Lecturer, Program, and Subject</h2>

                    <p>Select to begin association between lecturer, program, and subject.</p>

                    <asp:Label Text="Lecturer" CssClass="label label-info" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlLecturer" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLecturer_SelectedIndexChanged"></asp:DropDownList>

                    <asp:Label Text="School" CssClass="label label-info" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlSchool" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" OnDataBound="ddlSchool_DataBound"></asp:DropDownList>

                    <asp:Label Text="Program" CssClass="label label-info" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlProgram" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlProgram_SelectedIndexChanged" OnDataBound="ddlProgram_DataBound"></asp:DropDownList>

                    <asp:Label Text="Subjects" CssClass="label label-info" runat="server" />
                    <asp:CheckBoxList runat="server" ID="cblSubjects"></asp:CheckBoxList>

                    <p>
                        <asp:Label runat="server" ID="lblSchoolLecturerProgramSubject_Status" Visible="true" />
                    </p>
                    <asp:Button Text="Associate" runat="server" ID="btnAssociate" CssClass="btn btn-primary" OnClick="btnAssociate_Click" />
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
