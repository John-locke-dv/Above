﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PdD2.DAOs;
using Tp2.Models;

namespace Tp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Logear(string usuario, string password)
        {
            var usuarioEncontrado = UsuariosDAO.getInstancia().usuarioExistente(usuario, password);
            if (usuarioEncontrado != null)
            {
                HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuarioEncontrado));
                ViewBag.sesion = usuarioEncontrado; return View("Login");
            }
            else
            {
                @ViewBag.msg = "El usuario no existe";
                return View("Index");
            }
        }

        

    }
}
