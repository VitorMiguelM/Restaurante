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
            List<Reserva> reserva = new ReservaRepositorio().ObterTodos();

            ViewBag.TituloPagina = "Reservas";

            ViewBag.Reserva = reserva;

            return View();

        }

        [HttpGet]

        public ActionResult Pedido()
        {
            List<Reserva> reserva = new ReservaRepositorio().ObterTodos();

            ViewBag.TituloPagina = "Reserva";

            ViewBag.Reserva = reserva;

            return View();

        }

        [HttpGet]

        public ActionResult Nao_Cadastrado()
        {
            ViewBag.TitutloPagina = "Reserva";

            return View();

        }

        [HttpGet]

        public ActionResult Store(Reserva reserva)
        {

            if (ModelState.IsValid)
            {
                int identificador = new ReservaRepositorio().Cadastro(reserva);
                return RedirectToAction("Editar", new { id = identificador });
            }
            ViewBag.reserva = reserva;

            return View();

        }
    }
}