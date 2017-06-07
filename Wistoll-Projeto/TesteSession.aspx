<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TesteSession.aspx.cs" Inherits="TesteSession" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbl" runat="server"></asp:Label><br />

        <asp:Menu ID="menu" runat="server">
            <Items>
                <asp:MenuItem Text="Cadastrar Usuario" Value="Cadastrar Usuario"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </div>
    </form>
</body>
</html>
