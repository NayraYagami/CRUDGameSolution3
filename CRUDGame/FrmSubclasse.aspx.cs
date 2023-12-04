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
                PopularLVs();
            }
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
            DDLClasse.DataValueField = "IdClasse";
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
                novaSubclasse.ClasseID = idClasse;

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
            if(e.CommandName == "Excluir")
            {
                var id = e.CommandArgument;
                if(id != null)
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
        }
    }
}