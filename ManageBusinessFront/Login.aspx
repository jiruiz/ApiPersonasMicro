<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="Login.aspx.cs" Inherits="ManageBusinessFront.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUser" runat="server" Text="Usuario"></asp:Label>
        </div>
        <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <p>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesión" OnClick="btnIniciarSesion_Click" />
            <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse"/>
        </p>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
