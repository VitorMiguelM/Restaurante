﻿using System;
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
    }
}