namespace INF354Project
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tblClient> tblClients { get; set; }
        public virtual DbSet<tblClientFurniture> tblClientFurnitures { get; set; }
        public virtual DbSet<tblFurniture> tblFurnitures { get; set; }
        public virtual DbSet<tblFurnitureType> tblFurnitureTypes { get; set; }
        public virtual DbSet<tblTitle> tblTitles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblClient>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tblClient>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<tblClient>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tblClient>()
                .HasMany(e => e.tblClientFurnitures)
                .WithRequired(e => e.tblClient)
                .HasForeignKey(e => e.clientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblFurniture>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tblFurniture>()
                .HasMany(e => e.tblClientFurnitures)
                .WithRequired(e => e.tblFurniture)
                .HasForeignKey(e => e.furnitureId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblFurnitureType>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<tblFurnitureType>()
                .HasMany(e => e.tblFurnitures)
                .WithRequired(e => e.tblFurnitureType)
                .HasForeignKey(e => e.typeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblTitle>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<tblTitle>()
                .HasMany(e => e.tblClients)
                .WithRequired(e => e.tblTitle)
                .HasForeignKey(e => e.titleID)
                .WillCascadeOnDelete(false);
        }
    }
}
