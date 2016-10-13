<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Schools.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <h2><asp:Label ID="lbSchIndex" runat="server" CssClass="page page-header" Text="School Index"></asp:Label></h2>

    <a href="Create.aspx" class="btn btn-primary">New School</a>

    <h3>List of Schools</h3>
    <asp:GridView runat="server" ID="gvSchools" CssClass="table table-bordered"
        EmptyDataText="There are no schools info at this time being." ShowHeaderWhenEmpty="true">
        <Columns>
            <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <h3>List of Associated School Lecturers</h3>
    <asp:GridView runat="server" ID="gvSchoolLecturers" CssClass="table table-bordered"
        EmptyDataText="There are no association of school lecturers at this time being." ShowHeaderWhenEmpty="true">
        <Columns>
            <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
