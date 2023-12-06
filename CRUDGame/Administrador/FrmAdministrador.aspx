﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmAdministrador.aspx.cs" Inherits="CRUDGame.Administrador.FrmAdministrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../estilos.css" rel="stylesheet" />
</head>
<body>
    

    <form id="form1" runat="server">

        <asp:LoginStatus ID="LoginStatus1" CssClass="login" runat="server" LoginText="Entrar" LogoutText="Sair" />
        <h1>Tipo de Perfil: Administrador</h1>
        
        <h3>Bem-vindo(a),
        <asp:LoginName ID="LoginName1" runat="server" />
        </h3>

        <div>
            <a href="~/Inicio" runat="server">Acessar Gerenciador</a>
        </div>
    </form>
</body>
</html>