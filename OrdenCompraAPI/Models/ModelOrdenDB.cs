namespace OrdenCompraAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelOrdenDB : DbContext
    {
        public ModelOrdenDB()
            : base("name=ModelOrdenDB")
        {
        }

        public virtual DbSet<ORDEN_COMPRA> ORDEN_COMPRA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ORDEN_COMPRA>()
                .Property(e => e.NOMBRE_VENDEDOR)
                .IsUnicode(false);

            modelBuilder.Entity<ORDEN_COMPRA>()
                .Property(e => e.DIRECCION_VENDEDOR)
                .IsUnicode(false);

            modelBuilder.Entity<ORDEN_COMPRA>()
                .Property(e => e.TELEFONO_VENDEDOR)
                .IsUnicode(false);

            modelBuilder.Entity<ORDEN_COMPRA>()
                .Property(e => e.NOMBRE_COMPRADOR)
                .IsUnicode(false);

            modelBuilder.Entity<ORDEN_COMPRA>()
                .Property(e => e.DIRECCION_COMPRADOR)
                .IsUnicode(false);

            modelBuilder.Entity<ORDEN_COMPRA>()
                .Property(e => e.TELEFONO_COMPRADOR)
                .IsUnicode(false);

            modelBuilder.Entity<ORDEN_COMPRA>()
                .Property(e => e.CIUDAD_ENTREGA)
                .IsUnicode(false);

            modelBuilder.Entity<ORDEN_COMPRA>()
                .Property(e => e.VALOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ORDEN_COMPRA>()
                .Property(e => e.VALOR_IVA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ORDEN_COMPRA>()
                .Property(e => e.AUTORIZADO_POR)
                .IsUnicode(false);

            modelBuilder.Entity<ORDEN_COMPRA>()
                .Property(e => e.OBSERVACIONES)
                .IsUnicode(false);

            modelBuilder.Entity<ORDEN_COMPRA>()
                .Property(e => e.PROCEDENCIA)
                .IsUnicode(false);
        }
    }
}
