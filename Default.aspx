<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_ASP_051_Mega_Challenge_War_v2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Play War<br />
            <br />
            <asp:Button ID="PlayButton" runat="server" OnClick="PlayButton_Click" Text="Play" />
            <br />
            <br />
            <br />
            <asp:Label ID="ResultLable" runat="server"></asp:Label>
        </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
