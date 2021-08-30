using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data_model;
using data_model.Manager;
using VPNET.Data.Model;
using Microsoft.AspNetCore.Http;
using Proyecto1.Models;

namespace Proyecto1.Controllers
{
    public class AccountController : Controller
    {
        Usuarios_Manager usuarios_Manager = new Usuarios_Manager();
        Productos_Manager Productos_Manager = new Productos_Manager();
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            var result = usuarios_Manager.LoginUsuario(Username, Password);

            if(result.Encontrado == true)
            {
                ViewBag.id = result.id;
                HttpContext.Session.SetString("UserID", result.id.ToString());
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                ViewBag.error = "Usuario o Contraseña Incrrectos";
                return View();
            }
        }

        public IActionResult VenderProducto()
        {
            return View();
        }
        [HttpPost]
        public IActionResult VenderProducto(Productos producto)
        {
            producto.IdVendedor = int.Parse(HttpContext.Session.GetString("UserID"));
            var result = Productos_Manager.PublicarProducto(producto);
            ViewBag.publicado = "Su producto se ha publicado correctamente";
            if(result == true)
            {
                return Redirect("~/Home/index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(string Usuario, string Correo, string Password)
        {
            var result = usuarios_Manager.registrarUser(Usuario, Password, Correo);
            if(result == "Ok")
            {
                return Redirect("~/Account/Login");
            }
            else
            {
                ViewBag.result = result;
                return View();
            }
        }
    }
}
