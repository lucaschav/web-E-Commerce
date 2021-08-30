
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using static System.Net.WebRequestMethods;

namespace VPNET.Data.Model
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? IdCategoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int IdVendedor { get; set; }
        public string Imagen { get; set; }
        [NotMapped]
        public string Categ { get; set; }
        [NotMapped]
        public IFormFile Foto { get; set; }




    }

}
