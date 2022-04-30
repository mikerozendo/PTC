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

        public IActionResult Index()
        {
            return View(_marcasService.ObterTodos());
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inserir(Marca obj)
        {
            return View("Index", _marcasService.Inserir(obj));
        }

        [HttpPost]
        public IActionResult Deletar(Marca obj)
        {
            _marcasService.Deletar(obj);
            return RedirectToAction("Index");
        }
    }
}
