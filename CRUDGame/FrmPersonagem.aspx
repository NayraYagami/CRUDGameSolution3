<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPersonagem.aspx.cs" Inherits="CRUDGame.FrmPersonagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gerenciar Personagens</title>
</head>
<body>
    <h1>Gerenciar Personagens</h1>
    <form id="form1" runat="server">
        <div>
            <a href="~/Inicio" runat="server">Início</a>
        </div>

        <fieldset>
            <legend>Criar novo personagem
            </legend>

            <p>
                <label>Habilidade:</label>
                <asp:DropDownList runat="server" ID="ddlHabilidade">
                </asp:DropDownList>
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
                <label>Nível:</label>
                <asp:TextBox runat="server" ID="txtNivel" />
            </p>

            <p>
                <label>Nome do Personagem:</label>
                <asp:TextBox runat="server" ID="txtNome" />
            </p>

            <p>
                <label>Data de nascimento:</label>
                <asp:TextBox runat="server" ID="txtDataNasc" TextMode="Date" />
            </p>

            <p>
                <label>Atributo:</label>
                <asp:DropDownList runat="server" ID="ddlAtributo">
                </asp:DropDownList>
            </p>

            <p>
                <label>Sexo:</label>
                <asp:TextBox runat="server" ID="txtSexo" />
            </p>

            <p>
                <label>Força:</label>
                <asp:TextBox runat="server" ID="txtForca" />
            </p>

            <p>
                <label>Destreza:</label>
                <asp:TextBox runat="server" ID="txtDestreza" />
            </p>

            <p>
                <label>Sabedoria:</label>
                <asp:TextBox runat="server" ID="txtSabedoria" />
            </p>

            <p>
                <label>Constituição :</label>
                <asp:TextBox runat="server" ID="txtConstituicao" />
            </p>

            <p>
                <label>Inteligência :</label>
                <asp:TextBox runat="server" ID="txtInteligencia" />
            </p>

            <p>
                <label>Carisma :</label>
                <asp:TextBox runat="server" ID="txtCarisma" />
            </p>

            <p>
                <label>Peso :</label>
                <asp:TextBox runat="server" ID="txtPeso" />
            </p>

            <p>
                <label>Altura:</label>
                <asp:TextBox runat="server" ID="txtAltura" />
            </p>

            <p>
                <label>Cor Cabelo:</label>
                <asp:DropDownList runat="server" ID="ddlCorCabelo">
                </asp:DropDownList>
            </p>

            <p>
                <label>Estilo Cabelo:</label>
                <asp:TextBox runat="server" ID="txtEstiloCabelo" />
            </p>

            <p>
                <label>Cor dos Olhos:</label>
                <asp:DropDownList runat="server" ID="ddlCorOlhos">
                </asp:DropDownList>
            </p>

            <p>
                <label>Cor da Pele:</label>
                <asp:DropDownList runat="server" ID="ddlCorPele">
                </asp:DropDownList>
            </p>

            <p>
                <asp:FileUpload ID="fpImagem" runat="server" />

            </p>

            <p>
                <asp:Button Text="Cadastrar"
                    runat="server"
                    ID="btnConfirmar" OnClick="btnConfirmar_Click1" />
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
