using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGame
{
    internal class PersonagemDAO
    {
        internal static String CadastrarPersonagem(Personagem personagem)
        {
            string mensagem = "";
            try
            {
                using (RPGDBEntities2 ctx = new RPGDBEntities2())
                {
                    ctx.Personagems.Add(personagem);
                    ctx.SaveChanges();
                    mensagem = "`Personagem " + personagem.Nome +
                        " cadastrado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        internal static Personagem Remover(int idPersonagem)
        {
            Personagem personagem = null;

            using (var ctx = new RPGDBEntities2())
            {
                personagem = ctx.Personagems.FirstOrDefault(
                        x => x.Id == idPersonagem
                     );
                ctx.Personagems.Remove(personagem);
                ctx.SaveChanges();
            }
            return personagem;
        }

        internal static Personagem ListarPersonagens(int id)
        {
            Personagem personagem = null;

            using (var ctx = new RPGDBEntities2())
            {
                personagem = ctx.Personagems.FirstOrDefault(
                        x => x.Id == id
                    );
            }

            return personagem;
        }

        internal static object ListarPersonagens()
        {
            List<Personagem> personagens = null;
            try
            {
                using (var ctx = new RPGDBEntities2())
                {
                    personagens = ctx.Personagems.OrderBy(
                        x => x.Nome).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return personagens;
        }
    }
}