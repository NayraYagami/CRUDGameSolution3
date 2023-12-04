<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmHabilidade.aspx.cs" Inherits="CRUDGame.FrmHabilidade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gerenciamento de Habilidades</title>
</head>
<body>
    <h1>Gerenciar Habilidades</h1>
    <form id="form1" runat="server">
        <div>
            <a href="~/Inicio" runat="server">Início</a>
        </div>

        <fieldset>
            <legend>
                Criar nova habilidade
            </legend>

            <p>
                <label>Nome da Habilidade:</label>
                <asp:TextBox runat="server" id="txtDescricao"/>
            </p>
            <p>
                <asp:Button Text="Cadastrar" 
                    runat="server" 
                    ID="btnConfirmar" OnClick="btnConfirmar_Click"/>
            </p>
            <p>
                <label id="lblMensagem" runat="server"></label>
            </p>
        </fieldset>

    </form>
</body>
</html>
