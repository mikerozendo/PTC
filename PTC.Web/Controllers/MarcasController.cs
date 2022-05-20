using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Services;

namespace PTC.Web.Controllers
{
    public class Marcas : Controller
    {
        private readonly IMarcasService _marcasService;

        public Marcas(IMarcasService marcasService)
        {
            _marcasService = marcasService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View( await Task.Run(() => _marcasService.ObterTodos()));
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(Marca obj)
        {
            return Content(await Task.Run(() => _marcasService.Inserir(obj)));
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(Marca obj)
        {
            await Task.Run(() => _marcasService.Deletar(obj));
            return await Task.Run(() => RedirectToAction(nameof(Index)));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            return View(await Task.Run(() => _marcasService.ObterPorId(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(Marca obj)
        {
            await Task.Run(() => _marcasService.Alterar(obj));
            return await Task.Run(() => RedirectToAction(nameof(Index)));
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return await Task.Run(() => Json(_marcasService.ObterTodos()));
        }
    }
}
