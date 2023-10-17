using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace clinicaveterinaria20.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }
        public virtual DbSet<Animale> Animale { get; set; }
        public virtual DbSet<Armadietti> Armadietti { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Cassetto> Cassetto { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Prodotti> Prodotti { get; set; }
        public virtual DbSet<Utente> Utente { get; set; }
        public virtual DbSet<Utilizzi> Utilizzi { get; set; }
        public virtual DbSet<Vendita> Vendita { get; set; }
        public virtual DbSet<Visita> Visita { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
