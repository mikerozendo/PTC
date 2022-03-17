using Microsoft.AspNetCore.Mvc;
using System;

namespace PTC.Web.Controllers
{
    public class Marcas : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public JsonResult Incluir()
        {
            throw new NotImplementedException();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Excluir()
        {
            return View();
        }
    }
}
