<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmGerenciarUsuario.aspx.cs" Inherits="CRUDGame.FrmGerenciarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../css/default.css" rel="stylesheet" />
    <title>Gerenciar Usuário</title>
</head>
<body>
    <h1>Gerenciar Usuário</h1>
    <form id="form1" runat="server">
        <div>
            <label>Nome do usuário:</label>
            <p>
                <input type="text" required="required" name="name" runat="server" id="txtNomeUsuario" />
            </p>

            <label>Perfil do usuário:</label>
            <p>
                <asp:DropDownList runat="server" ID="ddlPerfilUsuario">
                </asp:DropDownList>
            </p>

            <label>Data de Nascimento:</label>
            <p>
                <input type="date" required="required" name="name" runat="server" id="txtDataNasc" />
            </p>

            <label>Login:</label>
            <p>
                <input type="text" required="required" name="name" runat="server" id="txtLogin" />
            </p>

            <label>Senha:</label>
            <p>
                <input type="password" required="required" name="name" runat="server" id="txtSenha" />
            </p>

            <label>Repita a senha:</label>
            <p>
                <input type="password" required="required" name="name" runat="server" id="txtRepetirSenha" />
            </p>
                        
            <p>
                <asp:Button Text="Cadastrar" ID="btnCadastrar" runat="server" OnClick="btnCadastrar_Click" />
            </p>

            <p>
                <label id="lblMensagem" runat="server"></label>
            </p>
        </div>
    </form>
</body>
</html>
