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
            return Content(_marcasService.Inserir(obj));
        }

        [HttpPost]
        public IActionResult Deletar(Marca obj)
        {
            _marcasService.Deletar(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            return View(_marcasService.ObterPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Marca obj)
        {
            _marcasService.Alterar(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Json(_marcasService.ObterTodos());
        }
    }
}
