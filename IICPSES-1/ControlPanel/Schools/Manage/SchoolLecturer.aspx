<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SchoolLecturer.aspx.cs" Inherits="IICPSES_1.ControlPanel.Schools.Manage.SchoolLecturer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-sm-12">
                    <h2>Manage Association between School Lecturer and Program Subject</h2>

                    <asp:Label Text="School Lecturer" CssClass="label label-info" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlSchoolLecturers" CssClass="form-control"
                        OnSelectedIndexChanged="ddlSchoolLecturers_SelectedIndexChanged" OnDataBound="ddlSchoolLecturers_DataBound" AutoPostBack="true">
                    </asp:DropDownList>

                    <asp:Label Text="Program Subject" CssClass="label label-info" runat="server" />
                    <asp:CheckBoxList runat="server" ID="cblProgramSubjects"></asp:CheckBoxList>

                    <p><asp:Label runat="server" ID="lblSchoolLecturerProgramSubject_Status" /></p>
                    <asp:Button Text="Associate" runat="server" ID="btnAssociate" CssClass="btn btn-primary" OnClick="btnAssociate_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
