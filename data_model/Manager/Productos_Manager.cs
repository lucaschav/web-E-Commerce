using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPNET.Data.Model;

namespace data_model.Manager
{
    public class Productos_Manager
    {
        private Model_Context db = new Model_Context();
        public Productos_Manager()
        {
        }

        public async Task<List<Productos>> GetProductosAsync()
        {

            var result = db.Productos.ToList();

            foreach(var i in result)
            {
                var cat = await db.Categorias.Where(x => x.Id == i.IdCategoria).FirstOrDefaultAsync();
                i.Categ = cat.Nobre;
            }

            return result;
        }
        public List<Productos> GetProductos()
        {
            var result = db.Productos.ToList();

            //foreach(var i in result)
            //{
            //    var cat = db.Categorias.Where(x => x.Id == i.IdCategoria).FirstOrDefault();
            //    i.Categ = cat.Nobre;
            //}

            return result;
        }

        public async Task<List<Productos>> FiltrarProductosAsync(string Busca)
        {
            var result = db.Productos.Where(x => x.Nombre.Contains(Busca)).ToList();

            foreach (var i in result)
            {
                var cat = await db.Categorias.Where(x => x.Id == i.IdCategoria).FirstOrDefaultAsync();
                i.Categ = cat.Nobre;
            }
            return result;
        }

        public Productos GetProductoId(int idProc)
        {
            var result = db.Productos.Where(x => x.Id == idProc).FirstOrDefault();
            var cat = db.Categorias.Where(x => x.Id == result.IdCategoria).FirstOrDefault();
            result.Categ = cat.Nobre;

            return result;
        }

        public List<Productos> GetCarrito(int IdUser)
        {
            List<Productos> lst = new List<Productos>();

            var result = db.Carrito.Where(x => x.idUsuario == IdUser).ToList();
            
            foreach(var item in result)
            {
                lst.Add(db.Productos.Where(x => x.Id == item.idProducto).FirstOrDefault());
            }
            foreach(var item in lst)
            {
                item.Stock = db.Carrito.Where(x => x.idUsuario == IdUser && x.idProducto == item.Id).Select(x => x.Cantidad).First();
            }
            return lst;
        }

        public async Task<bool> AgregarAlCarritoAsync(int idUser, int idProc, int Cantidad)
        {
            try
            {
                var result = db.Carrito.Where(x => x.idUsuario == idUser && x.idProducto == idProc).FirstOrDefault();
                if (result != null)
                {
                    result.Cantidad += Cantidad;

                    db.Entry(result).State = EntityState.Modified;
                }
                else
                {
                    Carrito carrito = new Carrito()
                    {
                        idProducto = idProc,
                        idUsuario = idUser,
                        Cantidad = Cantidad
                    };

                    db.Carrito.Add(carrito);
                }
                await db.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool PasarApagos(int idUser)
        {
            try
            {
                List<Carrito> lstCarritoPase = db.Carrito.Where(x => x.idUsuario == idUser).ToList();

                foreach (var item in lstCarritoPase)
                {
                    LogCompras logcomp = new LogCompras()
                    {
                        Cantidad = item.Cantidad,
                        IdProducto = item.idProducto,
                        IdUser = item.idUsuario
                    };
                    db.LogCompras.Add(logcomp);
                    db.Carrito.Remove(item);
                    db.SaveChanges();
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<Productos> GetMisCompras(int IdUser)
        {
            List<Productos> lst = new List<Productos>();

            var result = db.LogCompras.Where(x => x.IdUser == IdUser).ToList();

            foreach (var item in result)
            {
                lst.Add(db.Productos.Where(x => x.Id == item.IdProducto).FirstOrDefault());
            }
            foreach (var item in lst)
            {
                item.Stock = db.Carrito.Where(x => x.idUsuario == IdUser && x.idProducto == item.Id).Select(x => x.Cantidad).FirstOrDefault();
            }
            return lst;
        }

        public async Task<bool> RemoverDelCarrito(int idUser, int idProc)
        {
            try
            {
                var result = await db.Carrito.Where(x => x.idUsuario == idUser && x.idProducto == idProc).FirstOrDefaultAsync();
                db.Carrito.Remove(result);
                db.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool PublicarProducto(Productos productos)
        {
            try
            {
                productos.IdCategoria = 1;
                productos.Imagen = ConvertFileToBase64(productos.Foto);
                db.Productos.Add(productos);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public string ConvertFileToBase64(IFormFile FileModel)
        {
            try
            {
                if (FileModel.Length > 0)
                {
                    var ms = new MemoryStream();
                    FileModel.CopyTo(ms);
                    var fileByte = ms.ToArray();
                    return Convert.ToBase64String(fileByte);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
