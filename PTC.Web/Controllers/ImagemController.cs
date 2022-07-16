using Microsoft.AspNetCore.Mvc;
using PTC.Domain.Interfaces.Services;

namespace PTC.WEB.Controllers
{
    public class ImagemController : BaseController
    {
        private readonly IImagemService _imagemService;

        public ImagemController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            _imagemService = (IImagemService)_serviceProvider.GetService(typeof(IImagemService));
        }

        [HttpGet]
        public async Task<IActionResult> ExibirImagensVeiculo()
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
