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
        public ActionResult Login()
        {
            List<Clientes> clientes = new ClientesRepositorio().ObterTodos();
            ViewBag.Clientes = clientes;
            return View();
        }
        
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
            ViewBag.TituloPagina = "Cadastro - Cliente";
            ViewBag.Cliente = new Clientes();
            return View();
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            Clientes clientes = new ClientesRepositorio().ObterPeloId(id);
            ViewBag.Cliente = clientes;
            return View();
        }
        [HttpGet]
        public ActionResult Excluir(int id)
        {
            bool apagado = new ClientesRepositorio().Excluir(id);
            return RedirectToAction("Lista");
        }
        [HttpPost]
        public ActionResult Store(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.CPF = cliente.CPF.Replace(".", "").Replace("-", "");
                int identificador = new ClientesRepositorio().Cadastrar(cliente);
                    return RedirectToAction("Index", new { id = identificador });   
            }

            ViewBag.cliente = cliente;
            return Redirect("Index");
        }
        [HttpPost]
        public ActionResult Update(Clientes cliente)
        {
            bool alterado = new ClientesRepositorio().Alterar(cliente);
            return Redirect("Lista");
        }

        [HttpPost]
        public ActionResult Login(string login, string senha)
        {
            var Identificador = new ReservaRepositorio().ObterLogin(login, senha);
            if (Identificador != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Usuário inválido!");
            }
            return View();
        }
    }
}