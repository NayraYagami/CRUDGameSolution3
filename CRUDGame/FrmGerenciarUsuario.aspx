<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmGerenciarUsuario.aspx.cs" Inherits="CRUDGame.FrmGerenciarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/default.css" rel="stylesheet" />
    <title>Gerenciar Usuário</title>
</head>
<body>
    <h1>Gerenciar Usuário</h1>
    <form id="formGerenciarUsuario" runat="server">
        <div>
            <a class="btnInicio" href="~/Inicio" runat="server">Início</a>
        </div>
        <div>
            <fieldset>
                <legend>Gerenciar Usuário
                </legend>
                <label>Nome do usuário:</label>
                <p>
                    <asp:TextBox ID="txtNomeUsuario" runat="server" />
                </p>


                <label>Perfil do usuário:</label>
                <p>
                    <asp:DropDownList runat="server" ID="ddlPerfilUsuario">
                    </asp:DropDownList>
                </p>

                <label>Data de Nascimento:</label>
                <p>
                    <asp:TextBox ID="txtDataNasc" runat="server" TextMode="Date"/>
                </p>

                <label>Login:</label>
                <p>
                    <asp:TextBox ID="txtLogin" runat="server" />
                </p>

                <label>Senha:</label>
                <p>
                    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"/>
                </p>

                <label>Repita a senha:</label>
                <p>
                    <asp:TextBox ID="txtRepetirSenha" runat="server" TextMode="Password"/>
                </p>

                <p>
                    <asp:Button Text="Cadastrar" ID="btnCadastrar" runat="server" OnClick="btnCadastrar_Click" />
                </p>

                <p>
                    <label id="lblMensagem" runat="server"></label>
                </p>
            </fieldset>
            <p>
                <asp:Button Text="Recarregar"
                    runat="server"
                    ID="Recarregar" OnClick="Recarregar_Click" />
            </p>
        </div>

        <h2>Usuários Cadastrados</h2>

        <table border="1" class="tabela">
            <tr>
                <th>Nome</th>
                <th>Login</th>
                <th>Data Nascimento</th>
                <th>Perfil Usuário</th>

            </tr>

            <asp:ListView runat="server" ID="lvUsuarios" OnItemCommand="lvUsuario_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("Id") %>
                        </td>
                        <td>
                            <%# Eval("Nome") %>
                        </td>
                        <td>
                            <%# Eval("DataNasc") %>
                        </td>
                        <td>
                            <%# Eval("PerfilUsuarioId") %>
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
                                OnClientClick="return confirm('Deseja realmente excluir esse Usuário?');" />
                        </td>
                    </tr>

                </ItemTemplate>
            </asp:ListView>
        </table>
    </form>
</body>
</html>
