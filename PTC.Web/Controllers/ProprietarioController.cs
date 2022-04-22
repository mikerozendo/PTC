using Microsoft.AspNetCore.Mvc;
using PTC.Domain.Entities;
using PTC.Domain.Enums;
using PTC.Domain.Interfaces.Services;
using System;

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
            return Content(_proprietarioService.Inserir(proprietario));
        }

        public IActionResult ObterFiltrados(DateTime? inicio, DateTime? termino, EnumSituacao situacao)
        {
            return Json(_proprietarioService.ObterFiltrados(inicio, termino, situacao));
        }
    }
}
