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
                <asp:Button Text="Cadastrar"
                    runat="server"
                    ID="btnConfirmar" OnClick="btnConfirmar_Click1" />
            </p>
            <p>
                <label id="lblMensagem" runat="server"></label>
            </p>
        </fieldset>

   <%--     <p>
            <asp:Image ID="Image1" runat="server" />
        </p>--%>

        <h2>Personagens cadastrados</h2>

        <table border="1" class="tabela">
            <tr>
                <th>Código</th>
                <th>Nome</th>
                <th>Habilidade</th>
                <th>Raça</th>
                <th>SubClasse</th>
                <th>Nível</th>
                <th>Data Nascimento</th>
                <th>Sexo</th>
                <th>Força</th>
                <th>Destreza</th>
                <th>Sabedoria</th>
                <th>Constituição</th>
                <th>Inteligência</th>
                <th>Carisma</th>
                <th>Peso</th>
                <th>Altura</th>
                <th>Cor Cabelo</th>
                <th>Estilo Cabelo</th>
                <th>Cor Olho</th>
                <th>Cor Pele</th>
                <th>Ações</th>
            </tr>

            <asp:ListView runat="server" ID="lvPersonagens" OnItemCommand="lvPersonagens_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("Id") %>
                        </td>
                        <td>
                            <%# Eval("Nome") %>
                        </td>
                        <td>
                            <%# Eval("HabilidadeId") %>
                        </td>
                        <td>
                            <%# Eval("RacaId") %>
                        </td>
                        <td>
                            <%# Eval("SubclasseId") %>
                        </td>
                        <td>
                            <%# Eval("Nivel") %>
                        </td>
                        <td>
                            <%# Eval("DataNasc") %>
                        </td>
                        <td>
                            <%# Eval("Sexo") %>
                        </td>
                        <td>
                            <%# Eval("Forca") %>
                        </td>
                        <td>
                            <%# Eval("Destreza") %>
                        </td>
                        <td>
                            <%# Eval("Sabedoria") %>
                        </td>
                        <td>
                            <%# Eval("Constituicao") %>
                        </td>
                        <td>
                            <%# Eval("Inteligencia") %>
                        </td>
                        <td>
                            <%# Eval("Carisma") %>
                        </td>
                        <td>
                            <%# Eval("Peso") %>
                        </td>
                        <td>
                            <%# Eval("Altura") %>
                        </td>
                        <td>
                            <%# Eval("CorCabeloId") %>
                        </td>
                        <td>
                            <%# Eval("EstiloCabelo") %>
                        </td>
                        <td>
                            <%# Eval("CorOlhoId") %>
                        </td>
                        <td>
                            <%# Eval("CorPeleId") %>
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
                                OnClientClick="return confirm('Deseja realmente excluir esse Personagem?');" />
                        </td>
                    </tr>

                </ItemTemplate>
            </asp:ListView>
        </table>

    </form>
</body>
</html>
