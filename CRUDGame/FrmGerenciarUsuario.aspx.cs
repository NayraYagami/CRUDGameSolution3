using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmGerenciarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<PerfilUsuario> perfis =
                    PerfilUsuarioDAO.ListarPerfis();
                AtualizarDDLPerfil(perfis);
            }
        }

        private void AtualizarDDLPerfil(List<PerfilUsuario> perfis)
        {
            ddlPerfilUsuario.DataSource = perfis;
            ddlPerfilUsuario.DataTextField = "Descricao";
            ddlPerfilUsuario.DataValueField = "IdPerfilUsuario";
            ddlPerfilUsuario.DataBind();
            ddlPerfilUsuario.Items.Insert(0, "Selecione..");
        }

        [Obsolete]
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var senha = txtSenha.Text;
                var repetirSenha = txtRepetirSenha.Text;

                if (senha == repetirSenha)
                {
                    if (ddlPerfilUsuario.SelectedIndex > 0)
                    {
                        Usuario usuario = new Usuario();
                        usuario.DataNasc = Convert.ToDateTime(txtDataNasc.Text);
                        usuario.Login = txtLogin.Text;
                        usuario.Nome = txtNomeUsuario.Text;
                        usuario.PerfilUsuarioId =
                            Convert.ToInt32(ddlPerfilUsuario.SelectedValue);

                        //Criptografando a senha
                        var senhaCriptografada =
                                FormsAuthentication.
                                HashPasswordForStoringInConfigFile(senha, "SHA1");
                        usuario.Senha = senhaCriptografada;

                        string mensagem = UsuarioDAO.CadastrarUsuario(usuario);

                        lblMensagem.InnerText = mensagem;
                        limparCampos();
                    }
                    else
                    {
                        lblMensagem.InnerText = "Selecione um Perfil de Usuário!";
                    }
                }
                else
                {
                    lblMensagem.InnerText = "As senhas devem ser iguais!";
                }
            }
            catch (Exception ex)
            {
                lblMensagem.InnerText = "Ops, algo deu errado!";
            }
            
        }

        private void limparCampos()
        {
            txtNomeUsuario.Text = "";
            ddlPerfilUsuario.Items.Insert(0, "Selecione..");
            ddlPerfilUsuario.SelectedIndex = 0;
            txtDataNasc.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtRepetirSenha.Text = "";
        }
        private void refresh(bool limparMensagem)
        {
            txtNomeUsuario.Text = "";
            if (limparMensagem)
            {
                lblMensagem.InnerText = "";
            }
            Response.Redirect("~/FrmGerenciarUsuario.aspx");
        }

        protected void Recarregar_Click(object sender, EventArgs e)
        {
            refresh(true);
        }

        protected void lvUsuario_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                limparCampos();
                btnCadastrar.Text = "Cadastrar";
                var id = e.CommandArgument;
                if (id != null)
                {
                    int idUsuario = Convert.ToInt32(id);
                    Usuario usuarioExcluido =
                        UsuarioDAO.Remover(idUsuario);
                    if (usuarioExcluido != null)
                    {
                        lblMensagem.InnerText = "Usuário " +
                            usuarioExcluido.Nome +
                            " excluído com sucesso!";
                        PopularLVs();
                        refresh(false);
                    }
                }
                Response.Redirect(Request.RawUrl, true);

            }
            else if (e.CommandName == "Visualizar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    Response.Redirect("~/GerenciarUsuarios.aspx?id=" + id + "&edit=false");
                }
            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    Response.Redirect("~/GerenciarUsuarios.aspx?id=" + id + "&edit=true");
                }
            }
        }

        private void PopularLVs()
        {
            var usuarios = UsuarioDAO.ListarUsuarios();
            PopularLVUsuarios(usuarios);
        }

        private void PopularLVUsuarios(object usuarios)
        {
            lvUsuarios.DataSource = usuarios;
            lvUsuarios.DataBind();
        }
    }
}