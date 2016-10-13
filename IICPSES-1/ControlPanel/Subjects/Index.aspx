<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Subjects.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <h2>
        <asp:Label runat="server" CssClass="page page-header" Text="Subject Index"></asp:Label></h2>

    <a href="Create.aspx" class="btn btn-primary">Create New Subject</a>

    <h3>List of Subjects</h3>
    <asp:GridView runat="server" ID="gvSubjects" CssClass="table table-bordered"
        EmptyDataText="There are no subjects info at this time being." AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
        <Columns>
            <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Subject Name" />
            <asp:BoundField DataField="Code" HeaderText="Subject Code" />
            <asp:BoundField DataField="DateAdded" HeaderText="Date Added" />
        </Columns>
    </asp:GridView>

</asp:Content>
