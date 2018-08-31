using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoFinal.Models;
using TrabalhoFinal.Repositorios;

namespace TrabalhoFinal.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        
        public ActionResult Lista()
        {
            List<Clientes> clientes = new ClientesRepositorio().ObterTodos();
            ViewBag.Clientes = clientes;
            return View();
        }

        // Pagina inicial do site
        public ActionResult Index()
        {
            ViewBag.TitluoPagina = "Restaurante Luxo IV ";
            return View();
        }
        [HttpGet]
        public ActionResult Cadastro()
        {
            ViewBag.TituloPagina = "Cadastro Cliente";
            ViewBag.Cliente = new Clientes();
            return View();
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            Clientes clientes = new ClientesRepositorio().ObterPeloId(id);
            ViewBag.Clientes = clientes;
            return View();
        }
        [HttpGet]
        public ActionResult Excluir(int id)
        {
            bool apagado = new ClientesRepositorio().Excluir(id);
            return null;
        }
        [HttpPost]
        public ActionResult Store(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                int identificador = new ClientesRepositorio().Cadastrar(cliente);
                return RedirectToAction("Editar", new { id = identificador });
            }
            ViewBag.cliente = cliente;
            return View("Cadastro");
        }
        [HttpPost]
        public ActionResult Update(Clientes cliente)
        {
            bool alterado = new ClientesRepositorio().Alterar(cliente);
            return null;
        }
    }
}