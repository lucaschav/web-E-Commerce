using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace VPNET.Data.Model.Mappings
{
    public class UsuariosMap : EntityTypeConfiguration<Usuarios>
    {
        public UsuariosMap()
        {
            this.HasKey(t => t.id);

            this.Property(t => t.Usuario).HasMaxLength(70);
            this.Property(t => t.Password).HasMaxLength(50);
            this.Property(t => t.Correo).HasMaxLength(150);

            this.ToTable("Usuarios");
            this.Property(t => t.id).HasColumnName("Id");
            this.Property(t => t.Usuario).HasColumnName("Usuario");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Correo).HasColumnName("Correo");
            this.Property(t => t.FotoPerfil).HasColumnName("FotoPerfil");
            this.Property(t => t.FotoPortada).HasColumnName("FotoPortada");


        }
    }
}

