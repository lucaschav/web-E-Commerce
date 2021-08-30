using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace VPNET.Data.Model.Mappings
{
    public class ImagenMap : EntityTypeConfiguration<Imagen>
    {

        public ImagenMap()
        {
            this.HasKey(t => t.Id);


            this.ToTable("Imagen");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdProducto).HasColumnName("IdProducto");
            this.Property(t => t.Image).HasColumnName("Imagen");


        }
    }
}

