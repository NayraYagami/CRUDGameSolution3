using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CRUDGame
{
    public class HabilidadeDAO
    {
        public static string CadastrarHabilidade(Habilidade novaHabilidade)
        {
            string mensagem = "";
            try
            {
                using (var ctx = new RPGDBEntities2())
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

        internal static Habilidade ListarHabilidades(int id)
        {
            {
                Habilidade habilidade = null;

                using (var ctx = new RPGDBEntities2())
                {
                    habilidade = ctx.Habilidades.FirstOrDefault(
                            x => x.Id == id
                        );
                }

                return habilidade;
            }
        }

        internal static Habilidade Remover(int idHabilidade)
        {
            Habilidade habilidade = null;

            using (var ctx = new RPGDBEntities2())
            {
                habilidade = ctx.Habilidades.FirstOrDefault(
                        x => x.Id == idHabilidade
                     );
                ctx.Habilidades.Remove(habilidade);
                ctx.SaveChanges();
            }
            return habilidade;
        }

        internal static object ListarHabilidades()
        {
            List<Habilidade> habilidades = null;
            try
            {
                using (var ctx = new RPGDBEntities2())
                {
                    habilidades = ctx.Habilidades.OrderBy(
                        x => x.Descricao).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return habilidades;
        }
    }
}