using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using PTC.Domain.Entities;
using PTC.Web.Models.Enums;
using PTC.Domain.Interfaces.Services;
using PTC.Web.Models.Interfaces.Services;
using PTC.Application.Dtos;
using System;

namespace PTC.Web.Controllers
{
    public class OperacaoController : Controller
    {
        private readonly IVeiculosService _veiculosService;
        private readonly IOperacaoService _operacaoService;
        private readonly EnumPastaArquivoIdentificador pasta;
        private readonly IHelperService _helperService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public OperacaoController(IVeiculosService veiculosService, IHelperService helperService, IWebHostEnvironment webHostEnvironment, IOperacaoService operacaoService)
        {
            _veiculosService = veiculosService;
            _helperService = helperService;
            _webHostEnvironment = webHostEnvironment;
            pasta = EnumPastaArquivoIdentificador.Veiculos;
            _operacaoService = operacaoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await Task.Run(() => _veiculosService.ObterTodos()));
        }

        [HttpGet]
        public async Task<IActionResult> Adicionar()
        {
            return await Task.Run(() => RedirectToAction("Adicionar","Veiculos"));
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(OperacaoViewModel obj)
        {
            //var mensagem = await Task.Run(() => _operacaoService.Inserir(obj));
            //await _helperService.GerarImagem(obj.Veiculo.Imagem, pasta, _webHostEnvironment.WebRootPath, mensagem);
            //return await Task.Run(() => Content(mensagem));
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(Veiculo obj)
        {
            await Task.Run(() => _veiculosService.Deletar(obj));
            return await Task.Run(() => RedirectToAction(nameof(Index))); 
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            return View(await Task.Run(() => _veiculosService.ObterPorId(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(Veiculo obj)
        {
            await Task.Run(() => _veiculosService.Alterar(obj));
            //await _helperService.AlterarImagem(obj.Imagem, pasta, _webHostEnvironment.WebRootPath, mensagem, obj.CaminhoImagem);
            return await Task.Run(() => RedirectToAction(nameof(Index)));
        }

        //[HttpGet]
        //public async Task<JsonResult> ObterTodos()
        //{
        //    return await Task.Run(() => Json(_veiculosService.ObterTodos()));
        //}
    }
}
