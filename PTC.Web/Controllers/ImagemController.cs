﻿using Microsoft.AspNetCore.Mvc;
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
            try
            {
                var caminhos = await _imagemService.ObterImagensVeiculosPorIdOperacao(idOperacao, true);
                var fileStream = _helperService.GerarImagensArquivoPDF(caminhos);
                return File(fileStream, "application/pdf", "pdf_file_name.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);        
            }
        }
    }
}
