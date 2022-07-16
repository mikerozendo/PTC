using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Services;

namespace PTC.WEB.Controllers
{
    public class Marcas : BaseController
    {
        private readonly IMarcasService _marcasService;

        public Marcas(IServiceProvider services) : base(services)
        {
            _marcasService = (IMarcasService)services.GetService(typeof(IMarcasService));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _marcasService.ObterTodos());
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(Marca obj)
        {
            return Content(await _marcasService.Inserir(obj));
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(Marca obj)
        {
            await _marcasService.Deletar(obj);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            return View(await _marcasService.ObterPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(Marca obj)
        {
            await _marcasService.Alterar(obj);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Json(await _marcasService.ObterTodos());
        }
    }
}
