<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmAdministrador.aspx.cs" Inherits="CRUDGame.Administrador.FrmAdministrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/default.css" rel="stylesheet" />
</head>
<body>
    

    <form id="form1" runat="server">

        
        <h1>Administrador</h1>
        
        <h3 class="TituloBemVindo">Bem-vindo(a),
        <asp:LoginName ID="LoginName1" runat="server" />
        </h3>

        <div>
            <a href="~/Inicio" runat="server">Acessar Gerenciador</a>
        </div>
        <asp:LoginStatus ID="LoginStatus1" CssClass="login" runat="server" LogoutText="Sair" />
    </form>

    
</body>
</html>
