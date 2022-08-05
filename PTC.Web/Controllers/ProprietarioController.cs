using Microsoft.AspNetCore.Mvc;
using PTC.Application.Dtos;
using PTC.Application.Mapper;
using PTC.Domain.Interfaces.Services;
using PTC.WEB.Models.Enums;

namespace PTC.WEB.Controllers
{
    public class ProprietarioController : BaseController
    {
        private readonly IProprietarioService _proprietarioService;

        public ProprietarioController(IServiceProvider services) : base(services)
        {
            _proprietarioService = (IProprietarioService)GetAppService(typeof(IProprietarioService));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var proprietarios = await _proprietarioService.ObterPorPeriodo(DateTime.Now.AddDays(-90).Date, DateTime.Now.AddDays(1).Date);
            return View(proprietarios.Select(ProprietarioMapper.ToViewModel).ToList());
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

            if (mensagem.ToLower().Contains("sucesso"))
            {
                await ImagemService(EnumPastaArquivoIdentificador.Proprietarios, proprietario.Imagem, mensagem, proprietario.CaminhoImagem);
                return Ok(mensagem);
            }

            return BadRequest(mensagem);
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar([FromRoute] int id)
        {
            try
            {
                var proprietario = await _proprietarioService.ObterPorId(id);
                if (proprietario is null) return BadRequest("Proprietario inexistente");

                await _proprietarioService
                    .Deletar(proprietario);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(ProprietarioViewModel obj)
        {
            var mensagem = await _proprietarioService.Alterar(ProprietarioMapper.ToDomain(obj));
            await ImagemService(EnumPastaArquivoIdentificador.Proprietarios, obj.Imagem, obj.CaminhoImagem);
            return Content(mensagem);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var proprietarios = await _proprietarioService.ObterTodos();
            return Json(proprietarios.Select(ProprietarioMapper.ToViewModel).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> ObterPorPeriodo(DateTime dataInicio, DateTime dataTermino, int pagina = 1)
        {
            var proprietarios = await _proprietarioService.ObterPorPeriodo(dataInicio, dataTermino, pagina);
            return Json(nameof(Index), proprietarios.Select(x => ProprietarioMapper.ToViewModel(x, pagina)).ToList());
        }
    }
}
