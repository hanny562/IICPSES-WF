<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.ControlPanel.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h1>System Overview</h1>

            <div class="container">
                <div class="row col-sm-4">
                    <div class="panel panel-info">
                        <div class="panel-heading">Statistics</div>
                        <div class="panel-body">
                            <strong>System Data Summary</strong>
                            <p>
                                There are
                        <asp:Label ID="lblCount_School" runat="server" Font-Bold="true"></asp:Label>
                                school(s) registered.
                            </p>
                            <p>
                                There are
                        <asp:Label ID="lblCount_Program" runat="server" Font-Bold="true"></asp:Label>
                                program(s) registered.
                            </p>
                            <p>
                                There are
                        <asp:Label ID="lblCount_Lecturer" runat="server" Font-Bold="true"></asp:Label>
                                lecturer(s) registered.
                            </p>
                            <p>
                                There are
                        <asp:Label ID="lblCount_Subject" runat="server" Font-Bold="true"></asp:Label>
                                subject(s) registered.
                            </p>
                            <p>
                                There are
                        <asp:Label ID="lblCount_Semester" runat="server" Font-Bold="true"></asp:Label>
                                semester(s) registered.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
