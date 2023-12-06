using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDGame
{
    internal class UsuarioDAO
    {
        internal static string CadastrarUsuario(Usuario usuario)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new RPGDBEntities2())
                {
                    ctx.Usuarios.Add(usuario);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        internal static Usuario Autenticar(string user, string passCript)
        {
            Usuario userAutenticado = null;

            try
            {
                using (var ctx = new RPGDBEntities2())
                {
                    userAutenticado = ctx.Usuarios.FirstOrDefault(
                            x => x.Login == user && x.Senha == passCript
                        );
                }
            }
            catch (Exception ex)
            {
                //Erro
            }

            return userAutenticado;
        }
    }
}