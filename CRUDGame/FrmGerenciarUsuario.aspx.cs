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
                PopularLVs();

                var queryString_ID = Request.QueryString["id"];
                var queryString_Edit = Request.QueryString["edit"];

                if (queryString_ID != null && queryString_Edit != null)
                {
                    int id = Convert.ToInt32(queryString_ID);
                    PreencherDados(id, queryString_Edit == "true");
                }
                PopularLVs();

            }
        }

        private void PreencherDados(int id, bool edit)
        {
            var usuario = UsuarioDAO.ListarUsuarios(id);
            txtNomeUsuario.Text = usuario.Nome;
            txtLogin.Text = usuario.Login;
            txtDataNasc.Text = usuario.DataNasc != null ? ((DateTime)usuario.DataNasc).ToString("yyyy-MM-dd") : usuario.DataNasc.ToString();

            if (edit)
            {
                btnCadastrar.Text = "Alterar";
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
                var cadastrando = btnCadastrar.Text == "Cadastrar";
                List<String> erros = new List<string>();

                if (txtNomeUsuario.Text == "")
                {
                    erros.Add("Nome vázio");
                }
                if (txtDataNasc.Text == "")
                {
                    erros.Add("Data de nascimento vázia!");
                }
                if (txtLogin.Text == "")
                {
                    erros.Add("Login não informado!");
                }
                if (txtSenha.Text == "")
                {
                    erros.Add("Senha não informada!");
                }
                if (txtRepetirSenha.Text == "")
                {
                    erros.Add("Repita a senha!");
                }

                if (erros == null || erros.Count == 0)
                {

                    Usuario usuario = null;
                    int id = -1;

                    if (cadastrando)
                    {
                        usuario = new Usuario();
                    }
                    else
                    {
                        var idQuery = Request.QueryString["id"];
                        if (idQuery != null)
                        {
                            id = Convert.ToInt32(idQuery);
                            usuario = UsuarioDAO.ListarUsuarios(id);
                        }
                    }
                    if (senha == repetirSenha)
                    {
                        if (ddlPerfilUsuario.SelectedIndex > 0)
                        {
                            usuario.Nome = txtNomeUsuario.Text;
                            usuario.Login = txtLogin.Text;
                            usuario.DataNasc = Convert.ToDateTime(txtDataNasc.Text);
                            usuario.PerfilUsuarioId = Convert.ToInt32(ddlPerfilUsuario.SelectedValue);
                            var senhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "SHA1");
                            usuario.Senha = senhaCriptografada;

                            if (cadastrando)
                            {
                                lblMensagem.InnerText = UsuarioDAO.CadastrarUsuario(usuario);
                            }
                            else
                            {
                                lblMensagem.InnerText = UsuarioDAO.AlterarUsuario(usuario);
                                btnCadastrar.Text = "Cadastrar";
                            }

                            limparCampos();
                            PopularLVs();                          
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
                        lblMensagem.InnerText = "Usuário " + usuarioExcluido.Nome + " excluído com sucesso!";
                        Response.Redirect("~/FrmLogin.aspx");
                    }
                }
                Response.Redirect(Request.RawUrl, true);

            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    Response.Redirect("~/FrmGerenciarUsuario.aspx?id=" + id + "&edit=true");
                }
            }
        }

        private void PopularLVs()
        {
            List<Usuario> usuarios = new List<Usuario>();
            var IdUsuarioLogado = Request.QueryString["id"];
            Usuario usuario = UsuarioDAO.ListarUsuarios(Convert.ToInt32(IdUsuarioLogado));
            usuarios.Add(usuario);
            PopularLVUsuarios(usuarios);
        }

        private void PopularLVUsuarios(object usuarios)
        {
            lvUsuarios.DataSource = usuarios;
            lvUsuarios.DataBind();
        }
    }
}