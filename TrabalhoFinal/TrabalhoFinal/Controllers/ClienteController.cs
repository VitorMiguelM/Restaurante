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
        [HttpGet]
        public ActionResult Index()
        {
            List<Clientes> clientes = new ClientesRepositorio().ObterTodos();
            ViewBag.Cliente = clientes;
            ViewBag.TituloPagina = "Clientes";
            return View();
        }
        [HttpGet]
        public ActionResult CadastroCliente()
        {
            ViewBag.TituloPagina = "Restaurante-CadastroCliente";
            ViewBag.Cliente = new Clientes();
            return View();
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            Clientes clientes = new ClientesRepositorio().
        }
    }
}