using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmPersonagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopularDDLs();
            }
        }

        private void PopularDDLs()
        {
            try
            {
                List<Raca> racas = RacaDAO.ListarRacas();
                List<Subclasse> subClasses = SubclasseDAO.ListarSubclasses();
                List<Atributo> atributos = AtributoDAO.ListarAtributos();

                PopularDDLRaca(racas);
                PopularDDlSubclasse(subClasses);
                PopularDDlAtributo(atributos);

            }
            catch (Exception ex)
            {
                lblMensagem.InnerText = ex.Message;
            }
        }

        private void PopularDDlAtributo(List<Atributo> atributos)
        {
            ddlAtributo.DataSource = atributos;
            ddlAtributo.DataTextField = "Carisma";
            ddlAtributo.DataValueField = "Id";
            ddlAtributo.DataBind();
            ddlAtributo.Items.Insert(0, "Selecione..");
        }

        private void PopularDDlSubclasse(List<Subclasse> subClasses)
        {
            ddlSubclasse.DataSource = subClasses;
            ddlSubclasse.DataTextField = "Descricao";
            ddlSubclasse.DataValueField = "Id";
            ddlSubclasse.DataBind();
            ddlSubclasse.Items.Insert(0, "Selecione..");
        }

        private void PopularDDLRaca(List<Raca> racas)
        {
            ddlRaca.DataSource = racas;
            ddlRaca.DataTextField = "Descricao";
            ddlRaca.DataValueField = "Id";
            ddlRaca.DataBind();
            ddlRaca.Items.Insert(0, "Selecione..");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

        protected void btnImagem_Click(object sender, EventArgs e)
        {
            if (fpImagem.HasFile)
            {
                var arquivo = fpImagem.PostedFile;
                var tipo = arquivo.ContentType;

                if (tipo.Contains("png"))
                {
                    var caminho = MapPath("~/upload");
                    var nomeArquivo = "89" + ".png";
                    var novoCaminho = caminho + "\\" + nomeArquivo;
                    arquivo.SaveAs(novoCaminho);
                    Image1.ImageUrl = "~/upload/" + nomeArquivo;
                }
            }
        }
    }
}