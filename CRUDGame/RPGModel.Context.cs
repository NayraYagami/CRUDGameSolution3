﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RPGDBEntities : DbContext
    {
        public RPGDBEntities()
            : base("name=RPGDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<Raca> Racas { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Subclasse> Subclasses { get; set; }
        public virtual DbSet<Aparencia> Aparencias { get; set; }
        public virtual DbSet<Atributo> Atributoes { get; set; }
        public virtual DbSet<Personagem> Personagens { get; set; }
    }
}
