using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoFinal.Models;

namespace TrabalhoFinal.Controllers
{
    public class FuncionariosController : Controller
    {
        // GET: Funcionarios
        [HttpGet]
        public ActionResult Index()
        {
            List<Funcionarios> funcionario = new FuncionariosRepositorio()
            return View();
        }
    }
}