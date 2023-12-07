<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmRaca.aspx.cs" Inherits="CRUDGame.FrmRaca" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gerenciamento de Raças</title>
</head>
<body>
    <h1>Gerenciar Raças</h1>
    <form id="form1" runat="server">
        <div>
            <a href="~/Inicio" runat="server">Início</a>
        </div>

        <fieldset>
            <legend>Criar nova Raça
            </legend>

            <p>
                <label>Nome da Raça:</label>
                <asp:TextBox runat="server" ID="txtDescricao" />
            </p>
            <p>
                <asp:Button Text="Cadastrar"
                    runat="server"
                    ID="btnConfirmar" OnClick="btnConfirmar_Click" />
            </p>
            <p>
                <label id="lblMensagem" runat="server"></label>
            </p>
        </fieldset>

         <p>
                <asp:Button Text="Recarregar"
                    runat="server"
                    ID="Recarregar" OnClick="Recarregar_Click"/>
            </p>

        <h2>Raças cadastradas</h2>

        <table border="1" class="tabela">
            <tr>
                <th>Código</th>
                <th>Descrição</th>
                <th>Ações</th>
            </tr>

            <asp:ListView runat="server" ID="lvRacas" OnItemCommand="lvRacas_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("Id") %>
                        </td>
                        <td>
                            <%# Eval("Descricao") %>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnVisualizar"
                                runat="server"
                                ImageUrl="img/view.svg"
                                CommandName="Visualizar"
                                CommandArgument='<%# Eval("Id") %>' />
                            <asp:ImageButton ID="btnEditar"
                                runat="server"
                                ImageUrl="img/edit.svg"
                                CommandName="Editar"
                                CommandArgument='<%# Eval("Id") %>' />
                            <asp:ImageButton ID="btnDeletar"
                                runat="server"
                                ImageUrl="img/delete.svg"
                                CommandName="Excluir"
                                CommandArgument='<%# Eval("Id") %>'
                                OnClientClick="return confirm('Deseja realmente excluir essa raça?');" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>

    </form>
</body>
</html>
