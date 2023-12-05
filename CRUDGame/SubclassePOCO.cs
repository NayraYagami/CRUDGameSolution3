using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDGame
{
    public partial class Subclasse
    {
        //Retorna a classe dessa subclasse
        private Classe getClasse;

        public Classe GetClasse
        {
            get {
                getClasse = ClasseDAO.ListarClasseSubClasse(Id);
                return getClasse; 
            }            
        }

    }
}
