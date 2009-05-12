<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Demo.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="ScriptText" runat="server" TextMode="MultiLine" Rows="10" Columns="80" />
        <br />
        <asp:TextBox ID="Output" runat="server" TextMode="MultiLine" Rows="10" Columns="80"/>
        <br />
        <asp:Button ID="Run" runat="server" OnClick="Run_Clicked" Text="Run" />   
    </div>
    </form>
</body>
</html>
