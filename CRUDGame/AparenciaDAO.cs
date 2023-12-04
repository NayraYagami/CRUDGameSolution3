using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGame
{
    internal class AparenciaDAO
    {
        internal static List<Aparencia> ListarAparencias()
        {
            List<Aparencia> aparencia = null;
            try
            {
                var sub = new Subclasse();

                using (var ctx = new RPGDBEntities())
                {
                    aparencia = ctx.Aparencias.OrderBy(
                        x => x.IdAparencia).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return aparencia;
        }
    }
}