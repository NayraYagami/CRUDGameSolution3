using System;
using System.Data.SqlClient;

namespace CRUDGame
{
    public class HabilidadeDAO
    {
        public static string CadastrarHabilidade(Habilidade novaHabilidade)
        {
            string mensagem = "";
            try
            {
                using (var ctx = new RPGDBEntities())
                {
                    Habilidade habilidade = ctx.Habilidades.Add(novaHabilidade);
                    ctx.SaveChanges();
                }

                mensagem = "Habilidade " + novaHabilidade.Descricao
                    + " cadastrada com sucesso!";
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    mensagem = "A habilidade " + novaHabilidade.Descricao + " já existe.";
                }
                else
                {
                    mensagem = "Ocorreu um erro: " + ex.Message;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("An error occurred while updating the entries"))
                {
                    mensagem = "A habilidade " + novaHabilidade.Descricao + " já existe.";
                }
                else
                {
                    mensagem = "Ocorreu um erro: " + ex.Message;
                }
            }

            return mensagem;
        }
    }
}