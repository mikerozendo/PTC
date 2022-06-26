using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using PTC.Domain.Entities;
using PTC.Application.Dtos;
using PTC.Web.Models.Enums;
using PTC.Application.Mapper;
using PTC.Domain.Interfaces.Services;
using PTC.Web.Models.Interfaces.Services;

namespace PTC.Web.Controllers
{
    public class OperacaoController : BaseController
    {
        private readonly IVeiculosService _veiculosService;
        private readonly IOperacaoService _operacaoService;
        private readonly EnumPastaArquivoIdentificador pasta;
        private readonly IHelperService _helperService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public OperacaoController(IServiceProvider services) : base(services)
        {
            _veiculosService = (IVeiculosService)_serviceProvider.GetService(typeof(IVeiculosService));
            _helperService = (IHelperService)_serviceProvider.GetService(typeof(IHelperService));
            _webHostEnvironment = (IWebHostEnvironment)_serviceProvider.GetService(typeof(IWebHostEnvironment));
            _operacaoService = (IOperacaoService)_serviceProvider.GetService(typeof(IOperacaoService));
            pasta = EnumPastaArquivoIdentificador.Veiculos;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _veiculosService.ObterTodos());
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(OperacaoViewModel obj)
        {
            var mensagem = await _operacaoService.Inserir(OperacaoMapper.ToDomain(obj));
            await _helperService.GerarImagem(obj.Imagem, pasta, _webHostEnvironment.WebRootPath, mensagem);
            return Content(mensagem);
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(OperacaoViewModel obj)
        {
            await _operacaoService.Deletar(OperacaoMapper.ToDomain(obj));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            return View(OperacaoMapper.ToViewModel(await _operacaoService.ObterPorId(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(Veiculo obj)
        {
            await _veiculosService.Alterar(obj);
            //await _helperService.AlterarImagem(obj.Imagem, pasta, _webHostEnvironment.WebRootPath, mensagem, obj.CaminhoImagem);
            return RedirectToAction(nameof(Index));
        }

    }
}
