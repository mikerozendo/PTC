using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PTC.Domain.Entities;
using PTC.Application.Dtos;
using PTC.Web.Models.Enums;
using PTC.Application.Mapper;
using PTC.Domain.Interfaces.Services;
using System.Linq;

namespace PTC.Web.Controllers
{
    public class OperacaoController : BaseController
    {
        private readonly IVeiculosService _veiculosService;
        private readonly IOperacaoService _operacaoService;

        public OperacaoController(IServiceProvider services) : base(services)
        {
            _veiculosService = (IVeiculosService)_serviceProvider.GetService(typeof(IVeiculosService));
            _operacaoService = (IOperacaoService)_serviceProvider.GetService(typeof(IOperacaoService));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lista = await _operacaoService.ObterTodos();
            return View(lista.Select(OperacaoMapper.ToViewModel).ToList());
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
            await ImagemService(EnumPastaArquivoIdentificador.Veiculos, obj.Imagem, mensagem);
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
            //await ImagemService(EnumPastaArquivoIdentificador.Veiculos, obj.Imagem, mensagem, obj.CaminhoImagem);
            return RedirectToAction(nameof(Index));
        }

    }
}
