using System;
using System.IO;

namespace CRUDGame
{
    internal class LogAcessoDAO
    {
        private const string CaminhoArquivoLog = "log_acessos.txt";
        internal static void RegistrarAcesso(Usuario userAutenticado, DateTime now)
        {
            try
            {
                string mensagemLog = $"Usuário {userAutenticado.Nome} acessou o sistema em {now}";

                File.AppendAllText(CaminhoArquivoLog, mensagemLog + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao registrar acesso: {ex.Message}");
            }
        }
    }
}