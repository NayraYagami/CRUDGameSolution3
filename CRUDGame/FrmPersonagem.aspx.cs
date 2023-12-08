using System;
using System.Collections.Generic;
using System.IO;
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
                var queryString_ID = Request.QueryString["id"];
                var queryString_Edit = Request.QueryString["edit"];
                PopularDDLs();

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
            var personagem = PersonagemDAO.ListarPersonagens(id);
            if (personagem != null)
            {
                txtNome.Text = personagem.Nome;
                txtAltura.Text = personagem.Altura.ToString();
                txtCarisma.Text = personagem.Carisma.ToString();
                txtDataNasc.Text = personagem.DataNasc != null ? ((DateTime)personagem.DataNasc).ToString("yyyy-MM-dd") : personagem.DataNasc.ToString();
                txtDestreza.Text = personagem.Destreza.ToString();
                txtEstiloCabelo.Text = personagem.EstiloCabelo.ToString();
                txtForca.Text = personagem.Forca.ToString();
                txtInteligencia.Text = personagem.Inteligencia.ToString();
                txtNivel.Text = personagem.Nivel.ToString();
                txtPeso.Text = personagem.Peso.ToString();
                txtSabedoria.Text = personagem.Sabedoria.ToString();
                txtSexo.Text = personagem.Sexo.ToString();
                txtConstituicao.Text = personagem.Constituicao.ToString();

                var CorCabelo = CorDAO.ListarCores(Convert.ToInt32(personagem.CorCabeloId));
                var CorOlhos = CorDAO.ListarCores(Convert.ToInt32(personagem.CorOlhoId));
                var CorPele = CorDAO.ListarCores(Convert.ToInt32(personagem.CorPeleId));
                var Habilidade = HabilidadeDAO.ListarHabilidades(Convert.ToInt32(personagem.HabilidadeId));
                var Raca = RacaDAO.ListarRacas(Convert.ToInt32(personagem.RacaId));
                var Subclasse = SubclasseDAO.ListarSubclasses(Convert.ToInt32(personagem.SubclasseId));

                preencherDDLs(CorCabelo, CorOlhos, CorPele, Habilidade, Raca, Subclasse);
            }

            //Verifica se iremos editar os dados ou não
            if (edit)
            {
                //Editando
                fpImagem.Visible = false;
                btnConfirmar.Text = "Alterar";
            }
            else
            {
                HabilitarDesabilitarCampos(false);
                string jpgPath = $"~/upload/{id}.jpg";
                string pngPath = $"~/upload/{id}.png";
                Image1.ImageUrl = File.Exists(Server.MapPath(jpgPath)) ? jpgPath : pngPath;
            }
        }

        private void preencherDDLs(Cor corCabelo, Cor corOlhos, Cor corPele, Habilidade habilidade, Raca raca, Subclasse subclasse)
        {
            List<Cor> cores = CorDAO.ListarCores();
            PopularDDLCorPele(cores, corPele);
            PopularDDLCorOlho(cores, corOlhos);
            PopularDDLCorCabelo(cores, corCabelo);
            List<Habilidade> habilidades = HabilidadeDAO.ListarHabilidades();
            PopularDDLHabilidade(habilidades, habilidade);
            List<Subclasse> subClasses = SubclasseDAO.ListarSubclasses();
            PopularDDlSubclasse(subClasses, subclasse);
            List<Raca> racas = RacaDAO.ListarRacas();
            PopularDDLRaca(racas, raca);
        }

        private void PopularDDLs()
        {
            try
            {
                List<Raca> racas = RacaDAO.ListarRacas();
                List<Subclasse> subClasses = SubclasseDAO.ListarSubclasses();
                List<Habilidade> habilidades = HabilidadeDAO.ListarHabilidades();
                List<Cor> cores = CorDAO.ListarCores();

                PopularDDLRaca(racas, null);
                PopularDDlSubclasse(subClasses, null);
                PopularDDLHabilidade(habilidades, null);
                PopularDDLCorCabelo(cores, null);
                PopularDDLCorOlho(cores, null);
                PopularDDLCorPele(cores, null);
            }
            catch (Exception ex)
            {
                lblMensagem.InnerText = ex.Message;
            }
        }

        private void PopularDDLCorPele(List<Cor> cores, Cor cor)
        {
            if (cor != null)
            {
                cores.Insert(0, cor);
            }
            ddlCorPele.DataSource = cores;
            ddlCorPele.DataTextField = "Descricao";
            ddlCorPele.DataValueField = "Id";
            ddlCorPele.DataBind();
            if (cor == null)
            {
                ddlCorPele.Items.Insert(0, "Selecione..");
            }

        }

        private void PopularDDLCorOlho(List<Cor> cores, Cor cor)
        {
            if (cor != null)
            {
                cores.Insert(0, cor);
            }
            ddlCorOlhos.DataSource = cores;
            ddlCorOlhos.DataTextField = "Descricao";
            ddlCorOlhos.DataValueField = "Id";
            ddlCorOlhos.DataBind();
            if (cor == null)
            {
                ddlCorOlhos.Items.Insert(0, "Selecione..");
            }
        }

        private void PopularDDLCorCabelo(List<Cor> cores, Cor cor)
        {
            if (cor != null)
            {
                cores.Insert(0, cor);
            }
            ddlCorCabelo.DataSource = cores;
            ddlCorCabelo.DataTextField = "Descricao";
            ddlCorCabelo.DataValueField = "Id";
            ddlCorCabelo.DataBind();
            if (cor == null)
            {
                ddlCorCabelo.Items.Insert(0, "Selecione..");
            }
        }

        private void PopularDDLHabilidade(List<Habilidade> habilidades, Habilidade habilidade)
        {
            if (habilidade != null)
            {
                habilidades.Insert(0, habilidade);
            }

            ddlHabilidade.DataSource = habilidades;
            ddlHabilidade.DataTextField = "Descricao";
            ddlHabilidade.DataValueField = "Id";
            ddlHabilidade.DataBind();
            if (habilidade == null)
            {
                ddlHabilidade.Items.Insert(0, "Selecione..");
            }
        }

        private void PopularDDlSubclasse(List<Subclasse> subClasses, Subclasse subclasse)

        {
            if (subclasse != null)
            {
                subClasses.Insert(0, subclasse);
            }
            ddlSubclasse.DataSource = subClasses;
            ddlSubclasse.DataTextField = "Descricao";
            ddlSubclasse.DataValueField = "Id";
            ddlSubclasse.DataBind();
            if (subclasse == null)
            {
                ddlSubclasse.Items.Insert(0, "Selecione..");
            }
        }

        private void PopularDDLRaca(List<Raca> racas, Raca raca)
        {
            if (raca != null)
            {
                racas.Insert(0, raca);
            }
            ddlRaca.DataSource = racas;
            ddlRaca.DataTextField = "Descricao";
            ddlRaca.DataValueField = "Id";
            ddlRaca.DataBind();
            if (raca == null)
            {
                ddlRaca.Items.Insert(0, "Selecione..");
            }
        }

        protected void btnConfirmar_Click1(object sender, EventArgs e)
        {
            String message = null;
            List<String> erros = new List<string>();
            var cadastrando = btnConfirmar.Text == "Cadastrar";

            if (txtNome.Text == "")
            {
                erros.Add("Nome vázio");
            }
            if (txtDataNasc.Text == "")
            {
                erros.Add("Data de nascimento vázia");
            }
            if (ddlHabilidade.SelectedValue == "Selecione..")
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
            if (ddlRaca.SelectedValue == "Selecione..")
            {
                erros.Add("Raça não informada");
            }
            if (ddlSubclasse.SelectedValue == "Selecione..")
            {
                erros.Add("Sub Classe não informada");
            }
            if (ddlCorPele.SelectedValue == "Selecione..")
            {
                erros.Add("Cor da Pele não informado");
            }
            if (ddlCorOlhos.SelectedValue == "Selecione..")
            {
                erros.Add("Cor dos olhos não informado");
            }
            if (ddlCorCabelo.SelectedValue == "Selecione..")
            {
                erros.Add("Cor do Cabelo não informado");
            }
            if (cadastrando)
            {
                if (!fpImagem.HasFile)
                {
                    erros.Add("Imagem não adicionada!");
                }
            }

            if (erros == null || erros.Count == 0)
            {
                Personagem personagem = null;
                int id = -1;

                if (cadastrando)
                {
                    personagem = new Personagem();
                }
                else
                {
                    //Alterando
                    var idQuery = Request.QueryString["id"];
                    if (idQuery != null)
                    {
                        id = Convert.ToInt32(idQuery);
                        personagem = PersonagemDAO.ListarPersonagens(id);
                    }
                }

                personagem.RacaId = Convert.ToInt32(ddlRaca.SelectedValue);
                personagem.SubclasseId = Convert.ToInt32(ddlSubclasse.SelectedValue);
                personagem.Nome = txtNome.Text;
                personagem.DataNasc = Convert.ToDateTime(txtDataNasc.Text);
                personagem.Nivel = Convert.ToInt32(txtNivel.Text);
                personagem.Sexo = txtSexo.Text;
                personagem.Altura = Convert.ToDecimal(txtAltura.Text);
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
                personagem.Peso = Convert.ToDecimal(txtPeso.Text);


                if (cadastrando)
                {
                    lblMensagem.InnerText = PersonagemDAO.CadastrarPersonagem(personagem);
                }
                else
                {
                    lblMensagem.InnerText = PersonagemDAO.AlterarPersonagem(personagem);
                    btnConfirmar.Text = "Cadastrar";
                    fpImagem.Visible = true;
                }

                limparCampos();

                var arquivo = fpImagem.PostedFile;
                if (arquivo != null)
                {
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
                PopularLVs();
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

        protected void lvPersonagens_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                limparCampos();
                btnConfirmar.Text = "Cadastrar";
                var id = e.CommandArgument;
                if (id != null)
                {
                    int idPersonagem = Convert.ToInt32(id);
                    Personagem personagemExcluido =
                        PersonagemDAO.Remover(idPersonagem);
                    if (personagemExcluido != null)
                    {
                        lblMensagem.InnerText = "Personagem " +
                            personagemExcluido.Nome +
                            " excluído com sucesso!";
                        var caminhoAbsoluto = MapPath("~/upload");
                        var nomeArquivoPNG = idPersonagem + ".png";
                        var nomeArquivoJPG = idPersonagem + ".jpg";

                        var localArquivoPNG = Path.Combine(caminhoAbsoluto, nomeArquivoPNG);
                        var localArquivoJPG = Path.Combine(caminhoAbsoluto, nomeArquivoJPG);

                        if (File.Exists(localArquivoPNG))
                        {
                            File.Delete(localArquivoPNG);
                        }

                        if (File.Exists(localArquivoJPG))
                        {
                            File.Delete(localArquivoJPG);
                        }
                        PopularLVs();
                        refresh(false);
                    }
                }
                Response.Redirect(Request.RawUrl, true);

            }
            else if (e.CommandName == "Visualizar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    Response.Redirect("~/Personagens?id=" + id + "&edit=false");
                }
            }
            else if (e.CommandName == "Editar")
            {
                var id = e.CommandArgument;
                if (id != null)
                {
                    Response.Redirect("~/Personagens?id=" + id + "&edit=true");
                }
            }
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtAltura.Text = "";
            txtCarisma.Text = "";
            txtDataNasc.Text = "";
            txtDestreza.Text = "";
            txtEstiloCabelo.Text = "";
            txtForca.Text = "";
            txtInteligencia.Text = "";
            txtNivel.Text = "";
            txtPeso.Text = "";
            txtSabedoria.Text = "";
            txtSexo.Text = "";
            txtConstituicao.Text = "";
            ddlCorCabelo.Items.Insert(0, "Selecione..");
            ddlCorCabelo.SelectedIndex = 0;
            ddlCorOlhos.Items.Insert(0, "Selecione..");
            ddlCorOlhos.SelectedIndex = 0;
            ddlCorPele.Items.Insert(0, "Selecione..");
            ddlCorPele.SelectedIndex = 0;
            ddlHabilidade.Items.Insert(0, "Selecione..");
            ddlHabilidade.SelectedIndex = 0;
            ddlRaca.Items.Insert(0, "Selecione..");
            ddlRaca.SelectedIndex = 0;
            ddlSubclasse.Items.Insert(0, "Selecione..");
            ddlSubclasse.SelectedIndex = 0;
            Image1.Visible = false;
        }

        private void PopularLVs()
        {
            var personagens = PersonagemDAO.ListarPersonagens();
            PopularLVPersonagens(personagens);
        }

        private void PopularLVPersonagens(object personagens)
        {
            lvPersonagens.DataSource = personagens;
            lvPersonagens.DataBind();
        }

        protected void CadastrarNovo_Click(object sender, EventArgs e)
        {
            refresh(true);
        }

        private void refresh(bool limparMensagem)
        {
            limparCampos();
            btnConfirmar.Text = "Cadastrar";
            fpImagem.Visible = true;
            if (limparMensagem)
            {
                lblMensagem.InnerText = "";
            }
            Response.Redirect("~/Personagens");
            HabilitarDesabilitarCampos(true);
        }

        private void HabilitarDesabilitarCampos(bool habilitar)
        {
            txtNome.Enabled = habilitar;
            txtAltura.Enabled = habilitar;
            txtCarisma.Enabled = habilitar;
            txtDataNasc.Enabled = habilitar;
            txtDestreza.Enabled = habilitar;
            txtEstiloCabelo.Enabled = habilitar;
            txtForca.Enabled = habilitar;
            txtInteligencia.Enabled = habilitar;
            txtNivel.Enabled = habilitar;
            txtPeso.Enabled = habilitar;
            txtSabedoria.Enabled = habilitar;
            txtSexo.Enabled = habilitar;
            txtConstituicao.Enabled = habilitar;
            ddlCorCabelo.Enabled = habilitar;
            ddlCorOlhos.Enabled = habilitar;
            ddlCorPele.Enabled = habilitar;
            ddlHabilidade.Enabled = habilitar;
            ddlRaca.Enabled = habilitar;
            ddlSubclasse.Enabled = habilitar;
            fpImagem.Visible = habilitar;
            btnConfirmar.Visible = habilitar;
            Image1.Visible = !habilitar;
        }
    }
}