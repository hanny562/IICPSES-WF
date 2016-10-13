<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Lecturers.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <h2>Lecturer Index</h2>
    <a href="Create.aspx" class="btn btn-primary">Create New Lecturer</a>

    <h3>List of Lecturers</h3>
    <asp:GridView ID="gvLecturers" runat="server" CssClass="table table-bordered"
         ShowHeader="true" ShowHeaderWhenEmpty="true" EmptyDataText="There are no lecturers information at the time being." AutoGenerateColumns="false"
         DataKeyNames="Id"
         OnRowDataBound="gvLecturers_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Lecturer Name" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                     <asp:HyperLink runat="server" ID="hlLecturer_Edit" CssClass="btn btn-success">Edit</asp:HyperLink> &nbsp;
                     <asp:HyperLink runat="server" ID="hlLecturer_Delete" CssClass="btn btn-danger">Delete</asp:HyperLink> 
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


</asp:Content>
