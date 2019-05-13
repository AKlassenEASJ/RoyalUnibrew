namespace REST_Service.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PakkeKontrolEF : DbContext
    {
        public PakkeKontrolEF()
            : base("name=PakkeKontrolEF")
        {
        }

        public virtual DbSet<Ansatte> Ansatte { get; set; }
        public virtual DbSet<Bemanding> Bemanding { get; set; }
        public virtual DbSet<DeltilbageMeldt> DeltilbageMeldt { get; set; }
        public virtual DbSet<Faerdigvare> Faerdigvare { get; set; }
        public virtual DbSet<PakkeKontrolEFM> PakkeKontrol { get; set; }
        public virtual DbSet<ProcessOrdre> ProcessOrdre { get; set; }
        public virtual DbSet<ProduktionsInformation> ProduktionsInformation { get; set; }
        public virtual DbSet<TappeKontrol> TappeKontrol { get; set; }
        public virtual DbSet<VaegtKontrol> VaegtKontrol { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ansatte>()
                .HasMany(e => e.Bemanding)
                .WithRequired(e => e.Ansatte)
                .HasForeignKey(e => e.Signatur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ansatte>()
                .HasMany(e => e.PakkeKontrol)
                .WithRequired(e => e.Ansatte)
                .HasForeignKey(e => e.Signatur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ansatte>()
                .HasMany(e => e.ProduktionsInformation)
                .WithRequired(e => e.Ansatte)
                .HasForeignKey(e => e.Signatur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ansatte>()
                .HasMany(e => e.TappeKontrol)
                .WithRequired(e => e.Ansatte)
                .HasForeignKey(e => e.Signatur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Faerdigvare>()
                .HasMany(e => e.ProcessOrdre)
                .WithRequired(e => e.Faerdigvare)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProcessOrdre>()
                .HasMany(e => e.Bemanding)
                .WithRequired(e => e.ProcessOrdre)
                .HasForeignKey(e => e.Process_Order_Nr)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProcessOrdre>()
                .HasMany(e => e.DeltilbageMeldt)
                .WithRequired(e => e.ProcessOrdre)
                .HasForeignKey(e => e.Process_Order_Nr)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProcessOrdre>()
                .HasMany(e => e.PakkeKontrol)
                .WithRequired(e => e.ProcessOrdre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProcessOrdre>()
                .HasOptional(e => e.ProduktionsInformation)
                .WithRequired(e => e.ProcessOrdre);

            modelBuilder.Entity<ProcessOrdre>()
                .HasMany(e => e.TappeKontrol)
                .WithRequired(e => e.ProcessOrdre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProcessOrdre>()
                .HasMany(e => e.VaegtKontrol)
                .WithRequired(e => e.ProcessOrdre)
                .WillCascadeOnDelete(false);
        }
    }
}
