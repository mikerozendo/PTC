using Microsoft.AspNetCore.Mvc;
using PTC.Domain.Entities;
using PTC.Application.Dtos;
using PTC.Application.Mapper;
using PTC.Domain.Interfaces.Services;
using PTC.WEB.Models.Enums;

namespace PTC.WEB.Controllers
{
    public class OperacaoController : BaseController
    {
        private readonly IVeiculosService _veiculosService;
        private readonly IOperacaoService _operacaoService;
        private readonly IProprietarioService _proprietarioService;

        public OperacaoController(IServiceProvider services) : base(services)
        {
            _veiculosService = (IVeiculosService)GetAppService(typeof(IVeiculosService));
            _operacaoService = (IOperacaoService)GetAppService(typeof(IOperacaoService));
            _proprietarioService = (IProprietarioService)GetAppService(typeof(IProprietarioService));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lista = await _operacaoService.ObterPorPeriodo(DateTime.Now.AddDays(-90).Date, DateTime.Now.AddDays(1).Date);
            return View(lista.Select(OperacaoMapper.ToViewModel).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Adicionar()
        {
            var proprietarios = await _proprietarioService.ObterPorPeriodo(DateTime.Now.AddDays(-90).Date, DateTime.Now.AddDays(1).Date);
            var selectList = proprietarios.ToViewModel();
            return View(selectList);
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(OperacaoViewModel obj)
        {
            var mensagem = await _operacaoService.Inserir(OperacaoMapper.ToDomain(obj, _webHostEnvironment.WebRootPath));

            if (mensagem.ToLower().Contains("sucesso"))
            {
                await ImagemService(EnumPastaArquivoIdentificador.Veiculos, obj.ArquivosImagens, mensagem, obj.CaminhoImagem);
                return Ok(mensagem);
            }

            return BadRequest(mensagem);
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar(int id)
        {
            var operacao = await _operacaoService.ObterPorId(id);
            if (operacao is null) return BadRequest("Você esta tentando deletar uma operação que não existe");

            try
            {
                await _operacaoService.Deletar(operacao); return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var operacao = OperacaoMapper.ToViewModel(await _operacaoService.ObterPorId(id));
            var proprietarios = await _proprietarioService.ObterPorPeriodo(DateTime.Now.AddDays(-90).Date, DateTime.Now.AddDays(1).Date);
            operacao.ProprietariosHtmlSelectList.AddRange(proprietarios.ToViewModel().ProprietariosHtmlSelectList);

            return View(operacao);
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
