using System;
using System.Text.Json;
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
        public async Task<IActionResult> Index()
        {
            return View(await Task.Run(() => _proprietarioService.ObterTodos()));
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
        public async Task<IActionResult> Editar(int id)
        {
            return View(await Task.Run(() => _proprietarioService.ObterPorId(id)));
        }

        [HttpGet]
        public async Task<IActionResult> FiltroDinamico(string filtro)
        {
            return View("Index", await Task.Run(() => _proprietarioService.Filtrar(filtro)));
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(Proprietario proprietario)
        {
            var mensagem = await Task.Run(() => _proprietarioService.Inserir(proprietario));
            await _helperService.GerarImagemProprietario(proprietario.Imagem, _webHostEnvironment.WebRootPath, mensagem);
            return await Task.Run(() => Content(mensagem)); 
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(Proprietario obj)
        {
            await Task.Run(() => _proprietarioService.Deletar(obj)); return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(Proprietario obj)
        {
            var mensagem = await Task.Run(() => _proprietarioService.Alterar(obj));
            await _helperService.AlterarImagemProprietario(obj.Imagem, _webHostEnvironment.WebRootPath, mensagem, obj.CaminhoImagem);
            return await Task.Run(() => Content(mensagem));
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return await Task.Run(() => Json(_proprietarioService.ObterTodos()));
        }
    }
}
