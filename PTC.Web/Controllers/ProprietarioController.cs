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
    public class ProprietarioController : Controller
    {
        private readonly IProprietarioService _proprietarioService;
        private readonly IHelperService _helperService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly EnumPastaArquivoIdentificador pasta;

        public ProprietarioController(IProprietarioService proprietarioService, IHelperService helperService, IWebHostEnvironment webHostEnvironment)
        {
            _proprietarioService = proprietarioService;
            _helperService = helperService;
            _webHostEnvironment = webHostEnvironment;
            pasta = EnumPastaArquivoIdentificador.Proprietarios;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await Task.Run(() => _proprietarioService.ObterTodos().Select(ProprietarioMapper.ToViewModel).ToList()));
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            return View(await Task.Run(() => ProprietarioMapper.ToViewModel(_proprietarioService.ObterPorId(id))));
        }

        [HttpGet]
        public async Task<IActionResult> FiltroDinamico(string filtro)
        {
            return View("Index", await Task.Run(() => _proprietarioService.Filtrar(filtro).Select(ProprietarioMapper.ToViewModel).ToList()));
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(ProprietarioViewModel proprietario)
        {
            var mensagem = await Task.Run(() => _proprietarioService.Inserir(ProprietarioMapper.ToDomain(proprietario)));
            await _helperService.GerarImagem(proprietario.Imagem, pasta, _webHostEnvironment.WebRootPath, mensagem);
            return await Task.Run(() => Content(mensagem)); 
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(ProprietarioViewModel proprietario)
        {
            await Task.Run(() => _proprietarioService.Deletar(ProprietarioMapper.ToDomain(proprietario))); return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(ProprietarioViewModel proprietario)
        {
            var mensagem = await Task.Run(() => _proprietarioService.Alterar(ProprietarioMapper.ToDomain(proprietario)));
            await _helperService.AlterarImagem(proprietario.Imagem, pasta, _webHostEnvironment.WebRootPath, mensagem, proprietario.CaminhoImagem);
            return await Task.Run(() => Content(mensagem));
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return await Task.Run(() => Json(_proprietarioService.ObterTodos().Select(ProprietarioMapper.ToViewModel).ToList()));
        }
    }
}
