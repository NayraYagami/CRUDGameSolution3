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
    }
}