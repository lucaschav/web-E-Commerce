using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace VPNET.Data.Model.Mappings
{
    public class ProductosMap : EntityTypeConfiguration<Productos>
    {

        public ProductosMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Nombre).HasMaxLength(80);
            this.Property(t => t.Descripcion).HasMaxLength(500);

            this.ToTable("Productos");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.IdCategoria).HasColumnName("IdCategoria");
            this.Property(t => t.Precio).HasColumnName("Precio");
            this.Property(t => t.Stock).HasColumnName("Stock");
            this.Property(t => t.IdVendedor).HasColumnName("IdVendedor");
            this.Property(t => t.Imagen).HasColumnName("Imagen");


        }
    }
}

