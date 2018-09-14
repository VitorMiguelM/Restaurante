using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoFinal.Models;
using TrabalhoFinal.Repositorios;

namespace TrabalhoFinal.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        [HttpGet]
        public ActionResult Index()
        {
            List<Funcionarios> funcionarios = new FuncionariosRepositorio().ObterTodos();
            ViewBag.Funcionario = funcionarios;
            ViewBag.TituloPagina = "Funcionarios";
            return View();
        }
        [HttpGet]
        public ActionResult CadastroFuncionario()
        {
            ViewBag.TituloPagina = "Restaurante-CadastroFuncionario";
            ViewBag.Funcionario = new Funcionarios();
            return View();
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            Funcionarios funcionario = new FuncionariosRepositorio().ObterPeloId(id);
            ViewBag.Funcionario = funcionario;
            return View();
        }
        [HttpGet]
        public 
            ActionResult Excluir(int id)
        {
            bool apagado = new FuncionariosRepositorio().Excluir(id);
            return null;
        }
        [HttpPost]
        public ActionResult Index(Funcionarios funcionario)
        {
            var identificador = new FuncionariosRepositorio().Cadastrar(funcionario);
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Editar", new { id = identificador });
            }
            else 
            {
                ModelState.AddModelError("", "cadastrado com sucesso");
            }
            ViewBag.funcionario = funcionario;return View("Cadastro");
            
        }

        [HttpPost]
        public ActionResult Update(Funcionarios funcionario)
        {
            bool alterado = new FuncionariosRepositorio().Alterar(funcionario);
            return null;
        }
    }
}