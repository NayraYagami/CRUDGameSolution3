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

        internal static Usuario Remover(int idUsuario)
        {
            Usuario usuario = null;

            using (var ctx = new RPGDBEntities2())
            {
                usuario = ctx.Usuarios.FirstOrDefault(
                        x => x.IdUsuario == idUsuario
                     );
                ctx.Usuarios.Remove(usuario);
                ctx.SaveChanges();
            }
            return usuario;
        }

        internal static Usuario ListarUsuarios(int id)
        {
            Usuario usuario = null;

            using (var ctx = new RPGDBEntities2())
            {
                usuario = ctx.Usuarios.FirstOrDefault(
                        x => x.IdUsuario == id
                    );
            }

            return usuario;
        }

        internal static object ListarUsuarios()
        {
            List<Usuario> usuarios = null;
            try
            {
                using (var ctx = new RPGDBEntities2())
                {
                    usuarios = ctx.Usuarios.OrderBy(
                        x => x.Nome).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return usuarios;
        }

        internal static string AlterarUsuario(Usuario novoUsuario)
        {
            string mensagem = "";
            try
            {
                using (RPGDBEntities2 ctx = new RPGDBEntities2())
                {
                    Usuario usuario = ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == novoUsuario.IdUsuario);
                    usuario.Nome = novoUsuario.Nome;
                    usuario.Login = novoUsuario.Login;
                    usuario.DataNasc = novoUsuario.DataNasc;
                    usuario.Senha = novoUsuario.Senha;
                    ctx.SaveChanges();
                    mensagem = "Usuário " + novoUsuario.Nome + " alterado com sucesso!";
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