using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmHabilidade : System.Web.UI.Page
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
            var habilidade = HabilidadeDAO.ListarHabilidades(id);
            txtDescricao.Text = habilidade.Descricao;

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

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;

            if (descricao != "")
            {
                Habilidade novaHabilidade = new Habilidade();
                novaHabilidade.Descricao = descricao;

                string mensagem =
                    HabilidadeDAO.CadastrarHabilidade(novaHabilidade);
                txtDescricao.Text = "";

                PopularLVs();

                lblMensagem.InnerText = mensagem;
            }
        }

        private void PopularLVs()
        {
            var habilidades = HabilidadeDAO.ListarHabilidades();
            PopularLVHabilidades(habilidades);
        }

        private void PopularLVHabilidades(object habilidades)
        {
            lvHabilidades.DataSource = habilidades;
            lvHabilidades.DataBind();
        }

        protected void lvHabilidades_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    int idHabilidade = Convert.ToInt32(id);
                    Habilidade habilidadeExcluida =
                        HabilidadeDAO.Remover(idHabilidade);
                    if (habilidadeExcluida != null)
                    {
                        lblMensagem.InnerText = "Habilidade " +
                            habilidadeExcluida.Descricao +
                            " excluída com sucesso!";
                        PopularLVs();
                        refresh(true);
                    }
                }
            }
            else if (e.CommandName == "Visualizar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    Response.Redirect("~/Habilidades?id=" + id + "&edit=false");
                }
            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    Response.Redirect("~/Habilidades?id=" + id + "&edit=true");
                }
            }
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
            Response.Redirect("~/Racas");
        }

        protected void Recarregar_Click(object sender, EventArgs e)
        {
            refresh(true);
        }
    }
}