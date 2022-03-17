using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTC.Web.Controllers
{
    public class VeiculoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
