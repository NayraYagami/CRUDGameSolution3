using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGame
{
    public class RacaDAO
    {
        /// <summary>
        /// Cadastra um nova raça no banco de dados.
        /// </summary>
        /// <param name="novaRaca">Objeto do tipo Raca.</param>
        /// <returns>Mensagem com informações sobre a operação.</returns>
        public static string CadastrarRaca(Raca novaRaca)
        {
            string mensagem = "";
            try
            {
                using (var ctx = new RPGDBEntities())
                {
                    ctx.Racas.Add(novaRaca);
                    ctx.SaveChanges();
                }

                mensagem = "Raça " + novaRaca.Descricao
                    + " cadastrada com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = "Ocorreu um erro: " + ex.Message;
            }

            return mensagem;
        }

        internal static List<Raca> ListarRacas()
        {
            List<Raca> racas = null;
            try
            {
                using (var ctx = new RPGDBEntities())
                {
                    racas = ctx.Racas.OrderBy(
                        x => x.Descricao).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return racas;
        }
    }
}