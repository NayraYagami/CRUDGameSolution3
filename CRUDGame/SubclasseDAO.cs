using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGame
{
    public class SubclasseDAO
    {
        public static string CadastrarSubclasse(Subclasse novaSubclasse)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new RPGDBEntities())
                {
                    ctx.Subclasses.Add(novaSubclasse);
                    ctx.SaveChanges();
                }
                mensagem = "Subclasse " + 
                    novaSubclasse.Descricao + " cadastrada com suceso!";
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        internal static List<Subclasse> ListarSubclasses()
        {
            List<Subclasse> subClasses = null;
            try
            {
                using (var ctx = new RPGDBEntities())
                {
                    subClasses = ctx.Subclasses.OrderBy(x => x.Descricao).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return subClasses;
        }

        public static Subclasse Remover(int idSubclasse)
        {
            Subclasse sub = null;

            using (var ctx = new RPGDBEntities())
            {
                sub = ctx.Subclasses.FirstOrDefault(
                        x => x.IdSubclasse == idSubclasse
                     );
                ctx.Subclasses.Remove(sub);
                ctx.SaveChanges();
            }


            return sub;
        }
    }
}