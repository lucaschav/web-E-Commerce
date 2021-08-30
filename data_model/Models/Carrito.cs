using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VPNET.Data.Model
{
    public partial class Carrito
    {
        public int ID { get; set; }
        public int idUsuario { get; set; }
        public int idProducto { get; set; }
        public int Cantidad { get; set; }




    }

}
