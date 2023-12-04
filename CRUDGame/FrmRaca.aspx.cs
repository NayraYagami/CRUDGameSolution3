using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDGame
{
    public partial class FrmRaca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            var descricao = txtDescricao.Text;

            if (descricao != "")
            {
                Raca novaRaca = new Raca();
                novaRaca.Descricao = descricao;

                string mensagem = RacaDAO.CadastrarRaca(novaRaca);

                lblMensagem.InnerText = mensagem;
                txtDescricao.Text = "";
            }
        }
    }
}