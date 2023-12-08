using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmClasse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
            var classe = ClasseDAO.ListarClasses(id);
            txtDescricao.Text = classe.Descricao;

            if (edit) {
                btnConfirmar.Text = "Alterar";
            }
            else {
                btnConfirmar.Visible = false;
                txtDescricao.Enabled = false;
            }
        }

        private void PopularLVs()
        {
            var classes = ClasseDAO.ListarClasses();
            PopularLVClasses(classes);
        }

        private void PopularLVClasses(List<Classe> classes)
        {
            lvClasses.DataSource = classes;
            lvClasses.DataBind();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            var cadastrando = btnConfirmar.Text == "Cadastrar";

            if (descricao != "")
            {
                Classe novaClasse = null;
                int id = -1;
                
                if (cadastrando)
                {
                    novaClasse = new Classe();
                }
                else
                {
                    var idQuery = Request.QueryString["id"];
                    if (idQuery != null)
                    {
                        id = Convert.ToInt32(idQuery);
                        novaClasse = ClasseDAO.ListarClasses(id);
                    }
                }
                novaClasse.Descricao = descricao;
                string mensagem = "";

                if (cadastrando)
                {
                    mensagem = ClasseDAO.CadastrarClasse(novaClasse);
                }
                else
                {
                    mensagem = ClasseDAO.AlterarClasse(novaClasse);
                    btnConfirmar.Text = "Cadastrar";
                }

                txtDescricao.Text = "";

                lblMensagem.InnerText = mensagem;
                PopularLVs();
            }
        }

        protected void lvClasses_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    int idClasse = Convert.ToInt32(id);
                    Classe subExcluida =
                        ClasseDAO.Remover(idClasse);
                    if (subExcluida != null)
                    {
                        lblMensagem.InnerText = "Classe " +
                            subExcluida.Descricao +
                            " excluída com sucesso!";
                        PopularLVs();
                        refresh(false);
                    }
                }
            }
            else if (e.CommandName == "Visualizar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    Response.Redirect("~/Classes?id=" + id + "&edit=false");
                }
            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    Response.Redirect("~/Classes?id=" + id + "&edit=true");
                }
            }
        }

        protected void Recarregar_Click(object sender, EventArgs e)
        {
            refresh(true);
        }

        private void refresh(bool limparMensagem)
        {
            txtDescricao.Text = "";
            txtDescricao.Enabled = true;
            btnConfirmar.Text = "Cadastrar";
            if (limparMensagem)
            {
                lblMensagem.InnerText = "";
            }
            Response.Redirect("~/Classes");
        }
    }
}