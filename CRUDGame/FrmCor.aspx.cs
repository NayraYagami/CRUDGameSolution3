using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmCor : System.Web.UI.Page
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
            var cor = CorDAO.ListarCores(id);
            txtDescricao.Text = cor.Descricao;

            if (edit)
            {
                btnConfirmar.Text = "Alterar";
            }
            else
            {
                btnConfirmar.Visible = false;
                txtDescricao.Enabled = false;
            }
        }

        protected void lvCores_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                txtDescricao.Text = "";
                btnConfirmar.Text = "Cadastrar";
                var id = e.CommandArgument;
                if (id != null)
                {
                    int idCor = Convert.ToInt32(id);
                    Cor corExcluida =
                        CorDAO.Remover(idCor);
                    if (corExcluida != null)
                    {
                        lblMensagem.InnerText = "Cor " +
                            corExcluida.Descricao +
                            " excluída com sucesso!";
                        PopularLVs();
                    }
                }
            }
            else if (e.CommandName == "Visualizar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    Response.Redirect("~/Cores?id=" + id + "&edit=false");
                }
            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    Response.Redirect("~/Cores?id=" + id + "&edit=true");
                }
            }
        }

        private void PopularLVs()
        {
            var cores = CorDAO.ListarCores();
            PopularLVCores(cores);
        }

        private void PopularLVCores(object cores)
        {
            lvCores.DataSource = cores;
            lvCores.DataBind();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            var cadastrando = btnConfirmar.Text == "Cadastrar";

            if (descricao != "")
            {
                Cor novaCor= null;

                int id = -1;

                if (cadastrando)
                {
                    novaCor = new Cor();
                }
                else
                {
                    var idQuery = Request.QueryString["id"];
                    if (idQuery != null)
                    {
                        id = Convert.ToInt32(idQuery);
                        novaCor = CorDAO.ListarCores(id);
                    }
                }

                novaCor.Descricao = descricao;


                string mensagem = "";

                if (cadastrando)
                {
                    mensagem = CorDAO.CadastrarCor(novaCor);
                }
                else
                {
                    mensagem = CorDAO.AlterarCor(novaCor);
                    btnConfirmar.Text = "Cadastrar";
                }

                txtDescricao.Text = "";

                lblMensagem.InnerText = mensagem;
                PopularLVs();
            }
        }
    }
}