using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmSubclasse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<Classe> classes = ClasseDAO.ListarClasses();
                PreencherDDLClasse(classes);
                var queryString_ID = Request.QueryString["id"];
                var queryString_Edit = Request.QueryString["edit"];

                if (queryString_ID != null && queryString_Edit != null)
                {
                    int id = Convert.ToInt32(queryString_ID);
                    PreencherDados(id, queryString_Edit == "true", classes);
                }
                PopularLVs();
            }
        }

        private void PreencherDados(int id, bool edit, List<Classe> classes)
        {
            Subclasse subclasse = SubclasseDAO.ListarSubClasses(id);
            txtDescricao.Text = subclasse.Descricao;

            if (edit)
            {
                btnConfirmar.Text = "Alterar";
                if (subclasse != null && subclasse.GetClasse != null)
                {
                    PreencherDDLClasse(classes, subclasse.GetClasse.Id);
                }
            }
            else
            {
                btnConfirmar.Visible = false;
                txtDescricao.Enabled = false;
            }
        }

        private void PreencherDDLClasse(List<Classe> classes, int classeIdSelecionada = -1)
        {
            DDLClasse.DataSource = classes;
            DDLClasse.DataTextField = "Descricao";
            DDLClasse.DataValueField = "Id";
            DDLClasse.DataBind();

            if (classeIdSelecionada != -1)
            {
                DDLClasse.Items.FindByValue(classeIdSelecionada.ToString()).Selected = true;
            }

            DDLClasse.Items.Insert(0, "Selecione..");
        }

        private void PopularLVs()
        {
            var subclasses = SubclasseDAO.ListarSubclasses();
            lvSubclasses.DataSource = subclasses;
            lvSubclasses.DataBind();
        }

        private void PreencherDDLClasse(List<Classe> classes)
        {
            DDLClasse.DataSource = classes;
            DDLClasse.DataTextField = "Descricao";
            DDLClasse.DataValueField = "Id";
            DDLClasse.DataBind();
            DDLClasse.Items.Insert(0, "Selecione..");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            int index = DDLClasse.SelectedIndex;

            if (index == 0)
            {
                lblMensagem.InnerText =
                    "Você precisa selecionar uma classe!";
            }
            else if (descricao != "")
            {
                //Criando uma instância da classe (objeto)
                Subclasse novaSubclasse = new Subclasse();
                //Preencher o objeto
                novaSubclasse.Descricao = descricao;

                //Capturando o id da Classe dessa subclasse
                int idClasse = Convert.ToInt32(
                    DDLClasse.SelectedValue);
                novaSubclasse.ClasseId = idClasse;

                string mensagem =
                    SubclasseDAO.CadastrarSubclasse(novaSubclasse);
                //Limpando o campo de texto
                txtDescricao.Text = "";

                lblMensagem.InnerText = mensagem;
                PopularLVs();
            }
        }

        protected void lvSubclasses_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    int idSubclasse = Convert.ToInt32(id);
                    Subclasse subExcluida =
                        SubclasseDAO.Remover(idSubclasse);
                    if (subExcluida != null)
                    {
                        lblMensagem.InnerText = "Subclasse " +
                            subExcluida.Descricao +
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
                    Response.Redirect("~/SubClasses?id=" + id + "&edit=false");
                }
            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    Response.Redirect("~/SubClasses?id=" + id + "&edit=true");
                }
            }
        }
    }
}