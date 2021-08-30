using data_model;
using data_model.Manager;
using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Client.PaymentMethod;
using MercadoPago.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VPNET.Data.Model;


namespace Proyecto1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Productos_Manager ManagerProductos = new Productos_Manager();
        private Categorias_Manager ManagerCategorias = new Categorias_Manager();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int pagina = 1)
        {
            int salto = ((pagina - 1) * 9);
            var result = ManagerProductos.GetProductos().Skip(salto).Take(9).ToList();
            int pagTotales = result.Count() / 9;
            ViewBag.pagTotal = pagTotales;
            ViewBag.Categ = ManagerCategorias.getCategorias();
            return View(result);
        }

        public async Task<IActionResult> Buscar(string producto)
        {
            var result = await ManagerProductos.FiltrarProductosAsync(producto);

            return View(result);
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ProductoDetalle(int idProc)
        {
            var result = ManagerProductos.GetProductoId(idProc);
            return View(result);
        }

        public IActionResult Carrito(int idUser)
        {
            var result = ManagerProductos.GetCarrito(idUser);
            foreach(var item in result)
            {
                item.Precio = decimal.Round(item.Precio * item.Stock,2);
            }
            ViewBag.total = decimal.Round(result.Sum(x => x.Precio), 2).ToString();

            return View(result);
        }
        [HttpPost]
        public async Task<JsonResult> AgregarAlCarrito(int IdProducto, int Cantidad = 1)
        {
            var result = await ManagerProductos.AgregarAlCarritoAsync(int.Parse(HttpContext.Session.GetString("UserID")), IdProducto, Cantidad);
            return Json(new { result = result });
        }
        //[HttpPost]
        public IActionResult mercadoPago()
        {
            int user = int.Parse(HttpContext.Session.GetString("UserID"));
            var result = ManagerProductos.GetCarrito(user);
            ViewBag.pasoTotal = decimal.Round(result.Sum(x => x.Precio), 0).ToString();
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> ProcesarPago(PaymentViewModel payment_receive)
        {
            MercadoPagoConfig.AccessToken = "TEST-5316299600415555-082717-dae723fc760471db3c8640fc97921a62-160059297";
            var Banco_Id = new PaymentMethodClient().List().Where(m => m.Name == payment_receive.Banco_Emisor).Select(m => m.Id).FirstOrDefault();
            var paymentRequest = new PaymentCreateRequest
            {
                TransactionAmount = payment_receive.TransactionAmount,
                Token = payment_receive.Token,
                Description = payment_receive.Description,
                Installments = payment_receive.Installments,
                PaymentMethodId = Banco_Id,
                Payer = new PaymentPayerRequest
                {
                    Email = payment_receive.Email,
                    Identification = new IdentificationRequest
                    {
                        Type = payment_receive.Tipo_Doc,
                        Number = payment_receive.Nro_Doc,
                    },
                },
            };
            var Payment = await new PaymentClient().CreateAsync(paymentRequest);
            if(Payment.Status == "approved")
            {
                var result = ManagerProductos.PasarApagos(int.Parse(HttpContext.Session.GetString("UserID")));
            }
            return Json(Payment);
        }

        public IActionResult MisCompras(int idUser)
        {
            var result = ManagerProductos.GetMisCompras(idUser);
            //ViewBag.total = decimal.Round(result.Sum(x => x.Precio), 2).ToString();

            return View(result);
        }

        public async Task<IActionResult> SacarDeCarrito(int idProc)
        {
            var result = await ManagerProductos.RemoverDelCarrito(int.Parse(HttpContext.Session.GetString("UserID")), idProc);
            return Redirect("~/Home/Carrito?idUser=" + HttpContext.Session.GetString("UserID"));
        }
    }
}
