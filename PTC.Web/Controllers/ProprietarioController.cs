using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using PTC.Web.Models.Enums;
using PTC.Application.Dtos;
using PTC.Application.Mapper;
using PTC.Domain.Interfaces.Services;
using PTC.Web.Models.Interfaces.Services;

namespace PTC.Web.Controllers
{
    public class ProprietarioController : BaseController
    {
        private readonly IProprietarioService _proprietarioService;
        private readonly IHelperService _helperService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly EnumPastaArquivoIdentificador pasta;

        public ProprietarioController(IServiceProvider services) : base(services)
        {
            _proprietarioService = (IProprietarioService)_serviceProvider.GetService(typeof(IProprietarioService));
            _helperService = (IHelperService)_serviceProvider.GetService(typeof(IHelperService));
            _webHostEnvironment = (IWebHostEnvironment)_serviceProvider.GetService(typeof(IWebHostEnvironment));
            pasta = EnumPastaArquivoIdentificador.Proprietarios;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lista = await _proprietarioService.ObterTodos();
            return View(lista.Select(ProprietarioMapper.ToViewModel).ToList());
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            return View(ProprietarioMapper.ToViewModel(await _proprietarioService.ObterPorId(id)));
        }

        [HttpGet]
        public async Task<IActionResult> FiltroDinamico(string filtro)
        {
            var proprietarios = await _proprietarioService.Filtrar(filtro);
            return View("Index", proprietarios.Select(ProprietarioMapper.ToViewModel).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(ProprietarioViewModel proprietario)
        {
            var mensagem = await _proprietarioService.Inserir(ProprietarioMapper.ToDomain(proprietario));
            await _helperService.GerarImagem(proprietario.Imagem, pasta, _webHostEnvironment.WebRootPath, mensagem);
            return Content(mensagem);
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(ProprietarioViewModel proprietario)
        {
            await _proprietarioService.Deletar(ProprietarioMapper.ToDomain(proprietario)); return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(ProprietarioViewModel proprietario)
        {
            var mensagem = await _proprietarioService.Alterar(ProprietarioMapper.ToDomain(proprietario));
            await _helperService.AlterarImagem(proprietario.Imagem, pasta, _webHostEnvironment.WebRootPath, mensagem, proprietario.CaminhoImagem);
            return Content(mensagem);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var proprietarios = await _proprietarioService.ObterTodos();
            return Json(proprietarios.Select(ProprietarioMapper.ToViewModel).ToList());
        }
    }
}
