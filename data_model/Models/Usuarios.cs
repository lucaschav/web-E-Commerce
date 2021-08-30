
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace VPNET.Data.Model
{
    public partial class Usuarios 
    {
        public int id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
        public string FotoPerfil { get; set; }
        public string FotoPortada { get; set; }

        [NotMapped]
        public bool Encontrado { get; set; }


    }

}
