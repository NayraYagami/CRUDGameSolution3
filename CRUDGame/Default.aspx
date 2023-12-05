<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUDGame.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <h1>Página Inicial</h1>
    <form id="form1" runat="server">
        <div>
            <a href="~/Classes" runat="server">Gerenciar Classes</a>
            <a runat="server" href="~/Racas">Gerenciar Raças</a>
            <a runat="server" href="~/Habilidades">Gerenciar Habilidades</a>
            <a runat="server" href="~/Subclasses">Gerenciar Subclasses</a>
            <a runat="server" href="~/Cores">Gerenciar Cores</a>
            <a runat="server" href="~/Personagens">Gerenciar Personagens</a>
            <a runat="server" href="~/Atributos">Gerenciar Atributos</a>
        </div>
    </form>
</body>
</html>
