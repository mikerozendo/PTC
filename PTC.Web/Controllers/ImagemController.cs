using Microsoft.AspNetCore.Mvc;
using PTC.Domain.Interfaces.Services;
using PTC.Web.Models.Interfaces.Services;

namespace PTC.WEB.Controllers
{
    public class ImagemController : Controller
    {
        private readonly IImagemService _imagemService;
        private readonly IGeracaoArquivoService _helperService;

        public ImagemController(IImagemService imagemService, IGeracaoArquivoService helperService)
        {
            _imagemService = imagemService;
            _helperService = helperService;
        }

        [HttpGet]
        public IActionResult ExibirImagensVeiculo()
        {
            return PartialView("_ImagensVeiculo");
        }

        [HttpGet]
        public async Task<JsonResult> ObterCaminhosImagensPorIdOperacao(int idOperacao)
        {
            return Json(await _imagemService.ObterImagensVeiculosPorIdOperacao(idOperacao,false));
        }

        [HttpGet]
        public async Task<IActionResult> DownloadImagensPorIdOperacao(int idOperacao)
        {
            var caminhos = await _imagemService.ObterImagensVeiculosPorIdOperacao(idOperacao, true);
            return new FileStreamResult(await _helperService.GerarImagensArquivoPDF(caminhos), "application/pdf");
        }
    }
}
