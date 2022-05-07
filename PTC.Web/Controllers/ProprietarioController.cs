using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTC.Domain.Entities;
using PTC.Domain.Enums;
using PTC.Domain.Interfaces.Services;
using PTC.Web.Models.Interfaces.Services;

namespace PTC.Web.Controllers
{
    public class ProprietarioController : Controller
    {
        private readonly IProprietarioService _proprietarioService;
        private readonly IHelperService _helperService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProprietarioController(IProprietarioService proprietarioService, IHelperService helperService, IWebHostEnvironment webHostEnvironment)
        {
            _proprietarioService = proprietarioService;
            _helperService = helperService;
            _webHostEnvironment = webHostEnvironment;
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
            var mensagem = _proprietarioService.Inserir(proprietario);
            _helperService.DeletarImagem(_webHostEnvironment.WebRootPath, proprietario.CaminhoImagem, mensagem);
            return Content(mensagem);
        }

        [HttpPost]
        public async Task<JsonResult> InserirImagem(IFormFile imagem)
        {
            return Json(await _helperService.GerarImagemProprietario(imagem, _webHostEnvironment.WebRootPath));
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
