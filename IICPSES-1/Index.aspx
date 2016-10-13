<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSurvey.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IICPSES.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="smSurveySelection" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="upSurveySelection">
        <ContentTemplate>

            <div class="col-sm-offset-4 col-sm-4">
                <h1>Survey</h1>

                <div class="dropdown">
                    <asp:Label ID="lbSurveySchool" CssClass="label label-info" runat="server" Text="Program"></asp:Label><br />
                    <asp:DropDownList ID="ddlSurveySchool" CssClass="form-control" runat="server" AutoPostBack="True" 
                        OnSelectedIndexChanged="ddlSurveySchool_SelectedIndexChanged"
                        >
                        <asp:ListItem Text="Please Select School" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <br />

                    <asp:Label ID="lbSurveyProgram" CssClass="label label-info" runat="server" Text="Program"></asp:Label><br />
                    <asp:DropDownList ID="ddlSurveyProgram" CssClass="form-control" runat="server" AutoPostBack="True" 
                        OnSelectedIndexChanged="ddlSurveyProgram_SelectedIndexChanged" 
                        >
                        <asp:ListItem Text="Please Select Program" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <br />

                    <asp:Label ID="lbSurveySubject" CssClass="label label-info" runat="server" Text="Subject"></asp:Label><br />
                    <asp:DropDownList ID="ddlSurveySubject" CssClass="form-control" runat="server" AutoPostBack="True" 
                     OnSelectedIndexChanged="ddlSurveySubject_SelectedIndexChanged" 
                        >
                        <asp:ListItem Text="Please Select Subject" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <br />

                    <asp:Label ID="lbSurveyLecturer" CssClass="label label-info" runat="server" Text="Subject"></asp:Label><br />
                    <asp:DropDownList ID="ddlSurveyLecturer" CssClass="form-control" runat="server" AutoPostBack="True" 
                     OnSelectedIndexChanged="ddlSurveyLecturer_SelectedIndexChanged" 
                        >
                        <asp:ListItem Text="Please Select Lecturer" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <br />

                    <asp:Label ID="lbSurveySemester" CssClass="label label-info" runat="server" Text="Semester"></asp:Label><br />
                    <asp:DropDownList ID="ddlSurveySemester" CssClass="form-control" runat="server" 
                        >
                        <asp:ListItem Text="Please Select Semester" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>

                <p><asp:Label runat="server" ID="lblSurvey_Status" /></p>

                <asp:Button Text="&raquo; Next" runat="server" ID="btnSurveyNext" CssClass="btn btn-primary" OnClick="btnSurveyNext_Click" />

                
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
