using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoFinal.Models;
using TrabalhoFinal.Repositorio;

namespace TrabalhoFinal.Controllers
{
    public class PratosController : Controller
    {
        // GET: Pratos
        [HttpGet]
        public ActionResult Index()
        {
            List<Pratos> pratos = new RestauranteRepositorio().ObterTodos();
            ViewBag.Pratos = pratos;
            ViewBag.tituloPagina = "Pratos";
            return View();
        }
        [HttpGet]
        public ActionResult CadastroPrato()
        {
            ViewBag.TituloPagina = "Restaurante-Cadastro";
            ViewBag.Prato = new Pratos();
            return View();
        }
        [HttpGet]
        public ActionResult Edita(int id)
        {
            Pratos pratos = new RestauranteRepositorio().O
        }
    }
}