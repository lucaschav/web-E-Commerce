using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using VPNET.Data.Model;
using VPNET.Data.Model.Mappings;

namespace data_model
{
    public class Model_Context : DbContext
    {
        //public Model_Context() : base(@"Server=DESKTOP-U4QDOTF\SQLEXPRESS;Database=BaseProyecto1;MultipleActiveResultSets=true;Persist Security Info=True;")
        public Model_Context() : base(@"Server = DESKTOP-U4QDOTF\SQLEXPRESS; Database=BaseProyecto1;Trusted_Connection=True;")
        {

        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Imagen> Imagen { get; set; }
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<LogCompras> LogCompras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuariosMap());
            modelBuilder.Configurations.Add(new CategoriasMap());
            modelBuilder.Configurations.Add(new ProductosMap());
            modelBuilder.Configurations.Add(new ImagenMap());
            modelBuilder.Configurations.Add(new CarritoMap());
            modelBuilder.Configurations.Add(new LogComprasMap());
        }
    }
}
