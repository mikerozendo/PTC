using System;
using Microsoft.AspNetCore.Mvc;
using PTC.Domain.Entities;
using PTC.Domain.Enums;
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

        [HttpGet]
        public IActionResult Index()
        {
            return View(_proprietarioService.ObterTodos());
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ObterFiltrados(DateTime inicio, DateTime termino, EnumSituacao situacao)
        {
            return View("Index", _proprietarioService.ObterFiltrados(inicio, termino, situacao));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            return View(_proprietarioService.ObterPorId(id));
        }

        [HttpGet]
        public IActionResult FiltroDinamico(string filtro)
        {
            return View("Index", _proprietarioService.Filtrar(filtro));
        }

        [HttpPost]
        public IActionResult Inserir(Proprietario proprietario)
        {
            return Content(_proprietarioService.Inserir(proprietario));
        }

        [HttpPost]
        public IActionResult Deletar(Proprietario obj)
        {
            _proprietarioService.Deletar(obj); return Ok();
        }

        [HttpPost]
        public IActionResult Alterar(Proprietario obj)
        {
            return Content(_proprietarioService.Alterar(obj));
        }
    }
}
