using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGame
{
    internal class AtributoDAO
    {
        internal static List<Atributo> ListarAtributos()
        {
            List<Atributo> atributos = null;
            try
            {
                using (var ctx = new RPGDBEntities2())
                {
                    atributos = ctx.Atributoes.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return atributos;
        }

        internal static Atributo ListarAtributos(int id)
        {
            Atributo atributo = null;

            using (var ctx = new RPGDBEntities2())
            {
                atributo = ctx.Atributoes.FirstOrDefault(
                        x => x.Id == id
                    );
            }

            return atributo;
        }

        internal static string CadastrarAtributo(Atributo novoAtributo)
        {
            string mensagem = "";

            try
            {
                using (RPGDBEntities2 ctx = new RPGDBEntities2())
                {
                    ctx.Atributoes.Add(novoAtributo);
                    ctx.SaveChanges();
                    mensagem = "Atributo " + novoAtributo.Descricao +
                        " cadastrado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        internal static string AlterarAtributo(Atributo novoAtributo)
        {
            string mensagem = "";

            try
            {
                using (RPGDBEntities2 ctx = new RPGDBEntities2())
                {
                    Atributo atributo = ctx.Atributoes.FirstOrDefault(
                        x => x.Id == novoAtributo.Id
                     );

                    atributo.Descricao = novoAtributo.Descricao;
                    ctx.SaveChanges();

                    mensagem = "Atributo " + novoAtributo.Descricao + " alterado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        internal static Atributo Remover(int idAtributo)
        {
            Atributo atributo = null;

            using (var ctx = new RPGDBEntities2())
            {
                atributo = ctx.Atributoes.FirstOrDefault(
                        x => x.Id == idAtributo
                     );
                ctx.Atributoes.Remove(atributo);
                ctx.SaveChanges();
            }
            return atributo;
        }
    }
}