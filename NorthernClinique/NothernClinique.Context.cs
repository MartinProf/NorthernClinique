﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NorthernClinique
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NorthernEntities : DbContext
    {
        public NorthernEntities()
            : base("name=NorthernEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admission> Admissions { get; set; }
        public virtual DbSet<Assurance> Assurances { get; set; }
        public virtual DbSet<Departement> Departements { get; set; }
        public virtual DbSet<Lit> Lits { get; set; }
        public virtual DbSet<Medecin> Medecins { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Type_Lit> Type_Lit { get; set; }
    }
}
