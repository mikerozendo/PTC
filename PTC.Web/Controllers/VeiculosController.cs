using Microsoft.AspNetCore.Mvc;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace PTC.Web.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly IVeiculosService _marcasService;

        public VeiculosController(IVeiculosService marcasService)
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
        public IActionResult Inserir(Veiculo obj)
        {
            return Content(_marcasService.Inserir(obj));
        }

        [HttpPost]
        public IActionResult Deletar(Veiculo obj)
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
        public IActionResult Alterar(Veiculo obj)
        {
            _marcasService.Alterar(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult ObterTodos()
        {
            return Json(_marcasService.ObterTodos());
        }
    }
}
