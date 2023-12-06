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

        internal static string AlterarPersonagem(Personagem personagem)
        {
            string mensagem = "";
            //Tratamento de erros
            try
            {
                using (RPGDBEntities2 ctx = new RPGDBEntities2())
                {
                    Personagem personagem1 = ctx.Personagems.FirstOrDefault(
                        x => x.Id == personagem.Id
                     );

                    personagem1.RacaId = personagem.RacaId;
                    personagem1.SubclasseId = personagem.SubclasseId;
                    personagem1.Nome = personagem.Nome;
                    personagem1.DataNasc = personagem.DataNasc;
                    personagem1.Nivel = personagem.Nivel;
                    personagem1.Sexo = personagem.Sexo;
                    personagem1.Altura = personagem.Altura;
                    personagem1.Carisma = personagem.Carisma;
                    personagem1.Constituicao = personagem.Constituicao;
                    personagem1.CorCabeloId = personagem.CorCabeloId;
                    personagem1.CorOlhoId = personagem.CorOlhoId;
                    personagem1.CorPeleId = personagem.CorPeleId;
                    personagem1.Destreza = personagem.Destreza;
                    personagem1.Forca = personagem.Forca;
                    personagem1.Inteligencia = personagem.Inteligencia;
                    personagem1.EstiloCabelo = personagem.EstiloCabelo;
                    personagem1.HabilidadeId = personagem.HabilidadeId;
                    personagem1.Sabedoria = personagem.Sabedoria;
                    personagem1.Peso = personagem.Peso;

                    ctx.SaveChanges();

                    mensagem = "Personagem " + personagem1.Nome + " alterado com sucesso!";
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