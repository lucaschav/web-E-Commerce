using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPNET.Data.Model;

namespace data_model.Manager
{
    public class Usuarios_Manager
    {
        private Model_Context db = new Model_Context();
        public Usuarios_Manager()
        {
        }
        public Usuarios LoginUsuario(string Usuario, string Password)
        {
            var result = db.Usuarios.Where(x => x.Usuario == Usuario && x.Password == Password).FirstOrDefault();
            if(result == null)
            {
                result = new Usuarios() { Encontrado = false };
            }
            else
            {
                result.Encontrado = true;
            }

            return result;
        }
        public Usuarios TraerUser(int idUser)
        {
            var result = db.Usuarios.Where(x => x.id == idUser).FirstOrDefault();

            return result;
        }

        public string registrarUser(string user, string pass, string correo)
        {
            if(user == db.Usuarios.Where(x => x.Usuario == user).Select(x => x.Usuario).FirstOrDefault())
            {
                return "Ya existe un usuario con ese nombre";
            }
            else
            {
                Usuarios usuario = new Usuarios()
                {
                    Usuario = user,
                    Correo = correo,
                    Password = pass
                };

                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return "Ok";
            }
        }
    }
}
