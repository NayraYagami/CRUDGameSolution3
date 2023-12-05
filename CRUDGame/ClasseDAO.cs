using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGame
{
    public class ClasseDAO
    {
        public static string CadastrarClasse(Classe novaClasse)
        {
            string mensagem = "";
            //Tratamento de erros
            try
            {
                using (RPGDBEntities2 ctx = new RPGDBEntities2())
                {
                    //Cadastrando uma nova classe
                    ctx.Classes.Add(novaClasse);
                    //Salvando as alterações no BD
                    ctx.SaveChanges();
                    mensagem = "Classe " + novaClasse.Descricao + 
                        " cadastrada com sucesso!";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        internal static Classe ListarClasseSubClasse(int id)
        {
            Subclasse sub = null;
            Classe classe = null;

            using (var ctx = new RPGDBEntities2())
            {
                sub = ctx.Subclasses.FirstOrDefault(
                        x => x.Id == id
                    );
                classe = ListarClasses(Convert.ToInt32(sub.ClasseId));
            }

            return classe;
        }

        /// <summary>
        /// Retorna uma classe, de acordo com o id.
        /// </summary>
        /// <param name="classeID"></param>
        /// <returns></returns>
        public static Classe ListarClasses(int classeID)
        {
            Classe classe = null;

            using (var ctx = new RPGDBEntities2())
            {
                classe = ctx.Classes.FirstOrDefault(
                        x => x.Id == classeID
                    );
            }
            
            return classe;
        }

        /// <summary>
        /// Retorna todas as classes cadastradas!
        /// </summary>
        /// <returns></returns>
        public static List<Classe> ListarClasses()
        {
            List<Classe> classes = null;
            try
            {
                using (var ctx = new RPGDBEntities2())
                {
                    classes = ctx.Classes.OrderBy(
                        x => x.Descricao).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return classes;
        }

        public static Classe Remover(int idClasse)
        {
            Classe classe = null;

            using (var ctx = new RPGDBEntities2())
            {
                classe = ctx.Classes.FirstOrDefault(
                        x => x.Id == idClasse
                     );
                ctx.Classes.Remove(classe);
                ctx.SaveChanges();
            }
            return classe;
        }

        public static string AlterarClasse(Classe novaClasse)
        {
            string mensagem = "";
            //Tratamento de erros
            try
            {
                using (RPGDBEntities2 ctx = new RPGDBEntities2())
                {
                    Classe classe = ctx.Classes.FirstOrDefault(
                        x => x.Id == novaClasse.Id
                     );

                    classe.Descricao = novaClasse.Descricao;
                    ctx.SaveChanges();

                    mensagem = "Classe " + novaClasse.Descricao + " alterada com sucesso!";
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