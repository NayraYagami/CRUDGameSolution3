using System;

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
    }
}