//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUDGame
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subclasse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subclasse()
        {
            this.Personagems = new HashSet<Personagem>();
        }
    
        public int IdSubclasse { get; set; }
        public string Descricao { get; set; }
        public int ClasseID { get; set; }
    
        public virtual Classe Classe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
