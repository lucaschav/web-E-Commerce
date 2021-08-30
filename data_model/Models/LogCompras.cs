using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VPNET.Data.Model
{
    public partial class LogCompras
    {
        public int Id { get; set; }
        public int? IdProducto { get; set; }
        public int? IdUser { get; set; }
        public int? Cantidad { get; set; }




    }

}
