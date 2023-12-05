using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmAtributo : System.Web.UI.Page
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
            var atributo = AtributoDAO.ListarAtributos(id);
            txtDescricao.Text = atributo.Descricao;

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
            var cadastrando = btnConfirmar.Text == "Cadastrar";

            if (descricao != "")
            {
                Atributo novoAtributo = null;

                int id = -1;

                if (cadastrando)
                {
                    novoAtributo = new Atributo();
                }
                else
                {
                    var idQuery = Request.QueryString["id"];
                    if (idQuery != null)
                    {
                        id = Convert.ToInt32(idQuery);
                        novoAtributo = AtributoDAO.ListarAtributos(id);
                    }
                }
                //Preencher o objeto
                novoAtributo.Descricao = descricao;


                string mensagem = "";

                if (cadastrando)
                {
                    mensagem = AtributoDAO.CadastrarAtributo(novoAtributo);
                }
                else
                {
                    mensagem = AtributoDAO.AlterarAtributo(novoAtributo);
                    btnConfirmar.Text = "Cadastrar";
                }

                //Limpando o campo de texto
                txtDescricao.Text = "";

                lblMensagem.InnerText = mensagem;
                PopularLVs();
            }
        }

        private void PopularLVs()
        {
            var atributos = AtributoDAO.ListarAtributos();
            PopularLVAtributos(atributos);
        }

        private void PopularLVAtributos(List<Atributo> atributos)
        {
            lvAtributos.DataSource = atributos;
            lvAtributos.DataBind();
        }

        protected void lvAtributos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                txtDescricao.Text = "";
                btnConfirmar.Text = "Cadastrar";
                var id = e.CommandArgument;
                if (id != null)
                {
                    int idAtributo = Convert.ToInt32(id);
                    Atributo atributoExcluido =
                        AtributoDAO.Remover(idAtributo);
                    if (atributoExcluido != null)
                    {
                        lblMensagem.InnerText = "Atributo " +
                            atributoExcluido.Descricao +
                            " excluído com sucesso!";
                        PopularLVs();
                    }
                }
            }
            else if (e.CommandName == "Visualizar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    Response.Redirect("~/Atributos?id=" + id + "&edit=false");
                }
            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    Response.Redirect("~/Atributos?id=" + id + "&edit=true");
                }
            }
        }
    }
}