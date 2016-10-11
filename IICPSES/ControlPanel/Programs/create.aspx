<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="create.aspx.cs" Inherits="IICPSES.ControlPanel.Programs.create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2>
                <asp:Label ID="lbProgramTitle" runat="server" CssClass="page page-header" Text="Create Programs"></asp:Label></h2>
            <br />

            <asp:Label Text="Program Name" CssClass="label label-info" runat="server" />
            <asp:TextBox runat="server" ID="txtPName" CssClass="form-control" placeholder="Program Name" required="required" autofocus="autofocus" />
            <br />
            <asp:Label Text="Program Code" CssClass="label label-info" runat="server" />
            <asp:TextBox runat="server" ID="txtPCode" CssClass="form-control" placeholder="PCode" required="required" autofocus="autofocus" />
            <p>
                <asp:Label runat="server" ID="lblStatus_CreateProgram" />
            </p>

            <asp:Button runat="server" ID="btnCreate" CssClass="btn btn-primary" Text="Create" />
        </div>
    </div>
</asp:Content>
