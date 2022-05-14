using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
        public async Task<IActionResult> Inserir(Proprietario proprietario)
        {
            var mensagem = _proprietarioService.Inserir(proprietario);
            await _helperService.GerarImagemProprietario(proprietario.Imagem, _webHostEnvironment.WebRootPath, mensagem);
            return Content(mensagem);
        }

        [HttpPost]
        public IActionResult Deletar(Proprietario obj)
        {
            _proprietarioService.Deletar(obj); return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(Proprietario obj)
        {
            var mensagem = _proprietarioService.Alterar(obj);
            await _helperService.AlterarImagemProprietario(obj.Imagem, _webHostEnvironment.WebRootPath, mensagem, obj.CaminhoImagem);
            return Content(mensagem);
        }
    }
}
