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
            //List<Reserva> reserva = new ReservaRepositorio().ObterTodos();
            ViewBag.TituloPagina = "Reservas";
            //ViewBag.Reserva = reserva;
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
        public ActionResult Editar(int id)
        {
            Reserva reservas = new ReservaRepositorio().ObterPeloId(id);
            ViewBag.Reserva = reservas;
            return View();
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            bool apagado = new ReservaRepositorio().Excluir(id);
            return null;
        }

        [HttpPost]
        public ActionResult Index(string login, string senha)
        {
           var Identificador = new ReservaRepositorio(). ObterLogin(login, senha);
           if (Identificador != null)
           {
               return RedirectToAction("Pedido");
           }
           else
           {
               ModelState.AddModelError("", "Usuario não possue um cadastro");
           }
           return View();
            
        }

        [HttpPost]
        public ActionResult Update(Reserva reservas)
        {
            bool alterado = new ReservaRepositorio().Alterar(reservas);
            return null;
        }
    }
}