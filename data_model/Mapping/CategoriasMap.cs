using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace VPNET.Data.Model.Mappings
{
    public class CategoriasMap : EntityTypeConfiguration<Categorias>
    {

        public CategoriasMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Nobre).HasMaxLength(50);

            this.ToTable("Categorias");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nobre).HasColumnName("Nobre");


        }
    }
}

