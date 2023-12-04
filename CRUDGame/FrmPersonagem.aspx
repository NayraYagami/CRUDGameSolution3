<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPersonagem.aspx.cs" Inherits="CRUDGame.FrmPersonagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gerenciar Personagens</title>
</head>
<body>
    <h1>Gerenciar Personagens</h1>
    <form id="form1" runat="server">
        <div>
            <a href="~/Inicio" runat="server">Início</a>
        </div>

        <fieldset>
            <legend>
                Criar novo personagem
            </legend>

            <p>
                <label>Nome do Personagem:</label>
                <asp:TextBox runat="server" id="txtNome" />
            </p>

            <p>
                <label>Data de nascimento:</label>
                <asp:TextBox runat="server" id="txtDataNasc" TextMode="Date" />
            </p>

            <p>
                <label>Nível:</label>
                <asp:TextBox runat="server" id="txtNivel"/>
            </p>

            <p>
                <label>Sexo:</label>
                <asp:TextBox runat="server" id="txtSexo"/>
            </p>

            <p>
                <label>Raça:</label>
                <asp:DropDownList runat="server" ID="ddlRaca">
                </asp:DropDownList>
            </p>

            <p>
                <label>Subclasse:</label>
                <asp:DropDownList runat="server" ID="ddlSubclasse">
                </asp:DropDownList>
            </p>

            <p>
                <%--Precisaremos rever e refatorar a aparência--%>
                <label>Aparência:</label>
                <asp:DropDownList runat="server" ID="ddlAparencia">
                </asp:DropDownList>
            </p>
            <p>
                <label>Atributo:</label>
                <asp:DropDownList runat="server" ID="ddlAtributo">
                </asp:DropDownList>
            </p>

            <p>
                <asp:FileUpload ID="fpImagem" runat="server" />

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

        <p>
            <asp:Image ID="Image1" runat="server" />
        </p>

    </form>
</body>
</html>
