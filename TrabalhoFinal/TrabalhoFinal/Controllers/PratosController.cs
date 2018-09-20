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
            List<Prato> pratos = new RestauranteRepositorio().ObterTodos();
            ViewBag.Pratos = pratos;
            ViewBag.TituloPagina = "Pratos";
            return View();
        }
        [HttpGet]
        public ActionResult Cadastro()
        {
            ViewBag.TituloPagina = "Pratos - CadastroPrato";
            ViewBag.Prato = new Prato();
            return View();
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            Prato pratos = new RestauranteRepositorio().ObterPeloId(id);
            ViewBag.Prato = pratos;
            ViewBag.TituloPagina = "Pratos";

            return View();
        }
        [HttpGet]
        public ActionResult Excluir(int id)
        {
            bool apagado = new RestauranteRepositorio().Excluir(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Store(Prato prato)
        {
            if (ModelState.IsValid)
            {
                int identificador = new RestauranteRepositorio().Cadastrar(prato);
                return RedirectToAction("Index", new { id = identificador });
            }

            ViewBag.Prato = prato;
            return View("Cadastro");
        }
        [HttpPost]
        public ActionResult Update(Prato prato)
        {
            bool alterado = new RestauranteRepositorio().Alterar(prato);
            return RedirectToAction("Index");
        }
       
        
    }
}