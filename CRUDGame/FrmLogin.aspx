<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs" Inherits="CRUDGame.FrmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Fomulário de Login</title>
    <link href="estilos.css" rel="stylesheet" />
</head>
<body>
    
    
    <form id="form1" runat="server">

        <asp:LoginStatus ID="LoginStatus1" CssClass="login" runat="server" LoginText="Entrar" LogoutText="Sair" />
        <h1>Sistema de Acesso</h1>
        <div>
            <label>Usuário:</label>
            <p>
                <input type="text" name="name" runat="server" id="txtUsuario" required="required" />
            </p>
            <label>Senha:</label>
            <p>
                <input type="password" name="name" runat="server" id="txtSenha" required="required" />
            </p>
            <p>
                <asp:Button Text="Entrar" 
                    runat="server" 
                    id="btnEntrar"
                    OnClick="btnEntrar_Click"
                    />
            </p>
        </div>
    </form>
</body>
</html>
