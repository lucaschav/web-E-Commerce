using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace VPNET.Data.Model.Mappings
{
    public class LogComprasMap : EntityTypeConfiguration<LogCompras>
    {

        public LogComprasMap()
        {
            this.HasKey(t => t.Id);


            this.ToTable("LogCompras");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdProducto).HasColumnName("IdProducto");
            this.Property(t => t.IdUser).HasColumnName("IdUser");
            this.Property(t => t.Cantidad).HasColumnName("Cantidad");


        }
    }
}

