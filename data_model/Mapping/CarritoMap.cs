using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace VPNET.Data.Model.Mappings
{
    public class CarritoMap : EntityTypeConfiguration<Carrito>
    {

        public CarritoMap()
        {
            this.HasKey(t => t.ID);


            this.ToTable("Carrito");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.idUsuario).HasColumnName("idUsuario");
            this.Property(t => t.idProducto).HasColumnName("idProducto");
            this.Property(t => t.Cantidad).HasColumnName("Cantidad");


        }
    }
}

