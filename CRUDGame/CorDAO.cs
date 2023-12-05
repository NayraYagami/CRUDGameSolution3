using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGame
{
    internal class CorDAO
    {
        internal static Cor Remover(int idCor)
        {
            Cor cor = null;

            using (var ctx = new RPGDBEntities2())
            {
                cor = ctx.Cors.FirstOrDefault(
                        x => x.Id == idCor
                     );
                ctx.Cors.Remove(cor);
                ctx.SaveChanges();
            }
            return cor;
        }

        internal static List<Cor> ListarCores()
        {
            List<Cor> cores = null;
            try
            {
                using (var ctx = new RPGDBEntities2())
                {
                    cores = ctx.Cors.OrderBy(
                        x => x.Descricao).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return cores;
        }

        internal static Cor ListarCores(int id)
        {
            Cor cor = null;

            using (var ctx = new RPGDBEntities2())
            {
                cor = ctx.Cors.FirstOrDefault(
                        x => x.Id == id
                    );
            }

            return cor;
        }

        internal static string CadastrarCor(Cor novaCor)
        {
            string mensagem = "";

            try
            {
                using (RPGDBEntities2 ctx = new RPGDBEntities2())
                {
                    ctx.Cors.Add(novaCor);
                    ctx.SaveChanges();
                    mensagem = "Cor " + novaCor.Descricao +
                        " cadastrada com sucesso!";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        internal static string AlterarCor(Cor novaCor)
        {
            string mensagem = "";

            try
            {
                using (RPGDBEntities2 ctx = new RPGDBEntities2())
                {
                    Cor cor = ctx.Cors.FirstOrDefault(
                        x => x.Id == novaCor.Id
                     );

                    cor.Descricao = novaCor.Descricao;
                    ctx.SaveChanges();

                    mensagem = "Cor " + novaCor.Descricao + " alterada com sucesso!";
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