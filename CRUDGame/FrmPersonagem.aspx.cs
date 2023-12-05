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
                List<Habilidade> habilidades = HabilidadeDAO.ListarHabilidades();
                List<Cor> cores = CorDAO.ListarCores();

                PopularDDLRaca(racas);
                PopularDDlSubclasse(subClasses);
                PopularDDlAtributo(atributos);
                PopularDDLHabilidade(habilidades);
                PopularDDLCorCabelo(cores);
                PopularDDLCorOlho(cores);
                PopularDDLCorPele(cores);

            }
            catch (Exception ex)
            {
                lblMensagem.InnerText = ex.Message;
            }
        }

        private void PopularDDLCorPele(List<Cor> cores)
        {
            ddlCorPele.DataSource = cores;
            ddlCorPele.DataTextField = "Descricao";
            ddlCorPele.DataValueField = "Id";
            ddlCorPele.DataBind();
            ddlCorPele.Items.Insert(0, "Selecione..");
        }

        private void PopularDDLCorOlho(List<Cor> cores)
        {
            ddlCorOlhos.DataSource = cores;
            ddlCorOlhos.DataTextField = "Descricao";
            ddlCorOlhos.DataValueField = "Id";
            ddlCorOlhos.DataBind();
            ddlCorOlhos.Items.Insert(0, "Selecione..");
        }

        private void PopularDDLCorCabelo(List<Cor> cores)
        {
            ddlCorCabelo.DataSource = cores;
            ddlCorCabelo.DataTextField = "Descricao";
            ddlCorCabelo.DataValueField = "Id";
            ddlCorCabelo.DataBind();
            ddlCorCabelo.Items.Insert(0, "Selecione..");
        }

        private void PopularDDLHabilidade(List<Habilidade> habilidades)
        {
            ddlHabilidade.DataSource = habilidades;
            ddlHabilidade.DataTextField = "Descricao";
            ddlHabilidade.DataValueField = "Id";
            ddlHabilidade.DataBind();
            ddlHabilidade.Items.Insert(0, "Selecione..");
        }

        private void PopularDDlAtributo(List<Atributo> atributos)
        {
            ddlAtributo.DataSource = atributos;
            ddlAtributo.DataTextField = "Descricao";
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
            String message = null;
            List<String> erros = new List<string>();
            if (txtNome.Text == "")
            {
                erros.Add("Nome vázio");
            }
            if (txtDataNasc.Text == "")
            {
                erros.Add("Data de nascimento vázia");
            }
            if (ddlHabilidade.SelectedIndex == 0)
            {
                erros.Add("Habilidade não informada");
            }
            if (txtConstituicao.Text == "")
            {
                erros.Add("Constituição não informada");
            }
            if (txtSabedoria.Text == "")
            {
                erros.Add("Sabedoria não informada");
            }
            if (txtInteligencia.Text == "")
            {
                erros.Add("Inteligência não informada");
            }
            if (txtCarisma.Text == "")
            {
                erros.Add("Carisma não informada");
            }
            if (txtAltura.Text == "")
            {
                erros.Add("Altura não informada");
            }
            if (txtPeso.Text == "")
            {
                erros.Add("Peso não informado");
            }
            if (txtEstiloCabelo.Text == "")
            {
                erros.Add("Estilo do Cabelo não informado");
            }
            if (txtNivel.Text == "")
            {
                erros.Add("Nível não informado");
            }
            if (txtSexo.Text == "")
            {
                erros.Add("Sexo não informado");
            }
            if (ddlRaca.SelectedIndex == 0)
            {
                erros.Add("Raça não informada");
            }
            if (ddlSubclasse.SelectedIndex == 0)
            {
                erros.Add("Sub Classe não informada");
            }
            if (ddlAtributo.SelectedIndex == 0)
            {
                erros.Add("Atributo não informado");
            }
            if (!fpImagem.HasFile)
            {
                erros.Add("Imagem precisa ser adicionada");
            }

            if (erros == null)
            {
                Personagem personagem = new Personagem();
                personagem.RacaId = Convert.ToInt32(ddlRaca.SelectedValue);
                personagem.AtributoId = Convert.ToInt32(ddlAtributo.SelectedValue);
                personagem.SubclasseId = Convert.ToInt32(ddlSubclasse.SelectedValue);
                personagem.Nome = txtNome.Text;
                personagem.DataNasc = Convert.ToDateTime(txtDataNasc.Text);
                personagem.Nivel = Convert.ToInt32(txtNivel.Text);
                personagem.Sexo = txtSexo.Text;
                personagem.Altura = Convert.ToInt32(txtAltura);
                personagem.Carisma = Convert.ToInt32(txtCarisma);
                personagem.Constituicao = Convert.ToInt32(txtConstituicao);
                personagem.CorCabeloId = Convert.ToInt32(ddlCorCabelo.SelectedValue);
                personagem.CorOlhoId = Convert.ToInt32(ddlCorOlhos.SelectedValue);
                personagem.CorPeleId = Convert.ToInt32(ddlCorPele.SelectedValue);
                personagem.Destreza = Convert.ToInt32(txtDestreza);
                personagem.Forca = Convert.ToInt32(txtForca);
                personagem.Inteligencia = Convert.ToInt32(txtInteligencia);
                personagem.EstiloCabelo = txtEstiloCabelo.Text;
                personagem.HabilidadeId = Convert.ToInt32(ddlHabilidade.SelectedValue);
                personagem.Sabedoria = Convert.ToInt32(txtSabedoria);

                lblMensagem.InnerText = PersonagemDAO.CadastrarPersonagem(personagem);

                var arquivo = fpImagem.PostedFile;
                var tipo = arquivo.ContentType;

                if (tipo.Contains("png"))
                {
                    var caminhoAbsoluto = MapPath("~/upload");
                    var nomeArquivo = personagem.Id + ".png";
                    var nomeSalvar = caminhoAbsoluto + "\\" + nomeArquivo;

                    arquivo.SaveAs(nomeSalvar);
                    Image1.ImageUrl = "~/upload/" + nomeArquivo;
                }
            }
            else
            {
                string errors = "";
                foreach (var item in erros)
                {
                    errors += item + ", ";
                }
                lblMensagem.InnerText = errors;
            }
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

        protected void btnConfirmar_Click1(object sender, EventArgs e)
        {
            String message = null;
            List<String> erros = new List<string>();
            if (txtNome.Text == "")
            {
                erros.Add("Nome vázio");
            }
            if (txtDataNasc.Text == "")
            {
                erros.Add("Data de nascimento vázia");
            }
            if (ddlHabilidade.SelectedIndex == 0)
            {
                erros.Add("Habilidade não informada");
            }
            if (txtConstituicao.Text == "")
            {
                erros.Add("Constituição não informada");
            }
            if (txtSabedoria.Text == "")
            {
                erros.Add("Sabedoria não informada");
            }
            if (txtInteligencia.Text == "")
            {
                erros.Add("Inteligência não informada");
            }
            if (txtCarisma.Text == "")
            {
                erros.Add("Carisma não informada");
            }
            if (txtAltura.Text == "")
            {
                erros.Add("Altura não informada");
            }
            if (txtPeso.Text == "")
            {
                erros.Add("Peso não informado");
            }
            if (txtEstiloCabelo.Text == "")
            {
                erros.Add("Estilo do Cabelo não informado");
            }
            if (txtNivel.Text == "")
            {
                erros.Add("Nível não informado");
            }
            if (txtSexo.Text == "")
            {
                erros.Add("Sexo não informado");
            }
            if (ddlRaca.SelectedIndex == 0)
            {
                erros.Add("Raça não informada");
            }
            if (ddlSubclasse.SelectedIndex == 0)
            {
                erros.Add("Sub Classe não informada");
            }
            if (ddlAtributo.SelectedIndex == 0)
            {
                erros.Add("Atributo não informado");
            }
            if (!fpImagem.HasFile)
            {
                erros.Add("Imagem precisa ser adicionada");
            }

            if (erros == null || erros.Count == 0)
            {
                Personagem personagem = new Personagem();
                personagem.RacaId = Convert.ToInt32(ddlRaca.SelectedValue);
                personagem.AtributoId = Convert.ToInt32(ddlAtributo.SelectedValue);
                personagem.SubclasseId = Convert.ToInt32(ddlSubclasse.SelectedValue);
                personagem.Nome = txtNome.Text;
                personagem.DataNasc = Convert.ToDateTime(txtDataNasc.Text);
                personagem.Nivel = Convert.ToInt32(txtNivel.Text);
                personagem.Sexo = txtSexo.Text;
                personagem.Altura = Convert.ToInt32(txtAltura.Text);
                personagem.Carisma = Convert.ToInt32(txtCarisma.Text);
                personagem.Constituicao = Convert.ToInt32(txtConstituicao.Text);
                personagem.CorCabeloId = Convert.ToInt32(ddlCorCabelo.SelectedValue);
                personagem.CorOlhoId = Convert.ToInt32(ddlCorOlhos.SelectedValue);
                personagem.CorPeleId = Convert.ToInt32(ddlCorPele.SelectedValue);
                personagem.Destreza = Convert.ToInt32(txtDestreza.Text);
                personagem.Forca = Convert.ToInt32(txtForca.Text);
                personagem.Inteligencia = Convert.ToInt32(txtInteligencia.Text);
                personagem.EstiloCabelo = txtEstiloCabelo.Text;
                personagem.HabilidadeId = Convert.ToInt32(ddlHabilidade.SelectedValue);
                personagem.Sabedoria = Convert.ToInt32(txtSabedoria.Text);
                personagem.Peso = Convert.ToInt32(txtPeso.Text);

                lblMensagem.InnerText = PersonagemDAO.CadastrarPersonagem(personagem);

                var arquivo = fpImagem.PostedFile;
                var tipo = arquivo.ContentType;

                if (tipo.Contains("png"))
                {
                    var caminhoAbsoluto = MapPath("~/upload");
                    var nomeArquivo = personagem.Id + ".png";
                    var nomeSalvar = caminhoAbsoluto + "\\" + nomeArquivo;

                    arquivo.SaveAs(nomeSalvar);
                    Image1.ImageUrl = "~/upload/" + nomeArquivo;
                }
                if (tipo.Contains("jpeg"))
                {
                    var caminhoAbsoluto = MapPath("~/upload");
                    var nomeArquivo = personagem.Id + ".jpg";
                    var nomeSalvar = caminhoAbsoluto + "\\" + nomeArquivo;

                    arquivo.SaveAs(nomeSalvar);
                    Image1.ImageUrl = "~/upload/" + nomeArquivo;
                }
            }
            else
            {
                string errors = "";
                foreach (var item in erros)
                {
                    errors += item + ", ";
                }
                lblMensagem.InnerText = errors;
            }
        }
    }
}