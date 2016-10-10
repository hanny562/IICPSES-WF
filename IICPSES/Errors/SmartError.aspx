<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SmartError.aspx.cs" Inherits="IICPSES.Errors.SmartError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmMain" runat="server">
    <div>
        <h1><asp:Label runat="server" ID="lblHttpErrorTitle" /></h1>
        <p><asp:Label runat="server" ID="lblHttpErrorDescription" /></p>
    </div>
    </form>
</body>
</html>
