using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoFinal.Models;
using TrabalhoFinal.Repositorios;

namespace TrabalhoFinal.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        [HttpGet]

        public ActionResult Index()
        {

            ViewBag.TituloPagina = "Reservas";

            return View();

        }

        [HttpGet]

        public ActionResult Pedido()
        {

            ViewBag.TituloPagina = "Reserva";

            return View();

        }

        [HttpGet]

        public ActionResult Nao_Cadastrado()
        {
            ViewBag.TitutloPagina = "Reserva";

            return View();

        }
    }
}