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

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;

            if (descricao != "")
            {
                //Criando uma instância da classe (objeto)
                Habilidade novaHabilidade = new Habilidade();
                //Preencher o objeto
                novaHabilidade.Descricao = descricao;

                string mensagem =
                    HabilidadeDAO.CadastrarHabilidade(novaHabilidade);
                //Limpando o campo de texto
                txtDescricao.Text = "";

                lblMensagem.InnerText = mensagem;
            }
        }
    }
}