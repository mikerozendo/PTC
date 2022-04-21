﻿using Microsoft.AspNetCore.Mvc;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Services;

namespace PTC.Web.Controllers
{
    public class ProprietarioController : Controller
    {
        private readonly IProprietarioService _proprietarioService;

        public ProprietarioController(IProprietarioService proprietarioService)
        {
            _proprietarioService = proprietarioService;
        }

        public IActionResult Index()
        {
            return View(_proprietarioService.ObterTodos());
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inserir(Proprietario proprietario)
        {
            var mensagem = _proprietarioService.Inserir(proprietario);
            return RedirectToAction("Index", "Proprietario");
            //return Json();
        }
    }
}
