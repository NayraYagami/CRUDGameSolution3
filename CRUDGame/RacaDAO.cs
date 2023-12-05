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
                using (var ctx = new RPGDBEntities2())
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

        internal static Raca ListarRacas(int id)
        {
            Raca raca = null;

            using (var ctx = new RPGDBEntities2())
            {
                raca = ctx.Racas.FirstOrDefault(
                        x => x.Id == id
                    );
            }

            return raca;
        }

        internal static List<Raca> ListarRacas()
        {
            List<Raca> racas = null;
            try
            {
                using (var ctx = new RPGDBEntities2())
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

        internal static Raca Remover(int idRaca)
        {
            Raca raca = null;

            using (var ctx = new RPGDBEntities2())
            {
                raca = ctx.Racas.FirstOrDefault(
                        x => x.Id == idRaca
                     );
                ctx.Racas.Remove(raca);
                ctx.SaveChanges();
            }
            return raca;
        }

        internal static string AlterarRaca(Raca novaRaca)
        {
            string mensagem = "";
            try
            {
                using (RPGDBEntities2 ctx = new RPGDBEntities2())
                {
                    Raca raca = ctx.Racas.FirstOrDefault(
                        x => x.Id == novaRaca.Id
                     );

                    raca.Descricao = novaRaca.Descricao;
                    ctx.SaveChanges();

                    mensagem = "Raca " + novaRaca.Descricao + " alterada com sucesso!";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }
    }
}