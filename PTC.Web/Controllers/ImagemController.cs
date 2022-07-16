using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTC.Domain.Interfaces.Services;
using PTC.Web.Models.Interfaces.Services;
using PTC.WEB.Models.Enums;

namespace PTC.WEB.Controllers
{
    public class ImagemController : Controller
    {
        private readonly IImagemService _imagemService;
        private readonly IHelperService _helperService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImagemController(IImagemService imagemService, IHelperService helperService, IWebHostEnvironment webHostEnvironment)
        {
            _imagemService = imagemService;
            _helperService = helperService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult ExibirImagensVeiculo()
        {
            return PartialView("_ImagensVeiculo");
        }

        [HttpGet]
        public async Task<JsonResult> ObterCaminhosImagensPorIdOperacao(int idOperacao)
        {
            return Json(await _imagemService.ObterImagensVeiculosPorIdOperacao(idOperacao));
        }
    }
}
