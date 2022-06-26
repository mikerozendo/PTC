using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PTC.Web.Models.Enums;
using PTC.Web.Models.Interfaces.Services;

namespace PTC.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IServiceProvider _serviceProvider;
        private readonly IHelperService _helperService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _helperService = (IHelperService)serviceProvider.GetService(typeof(IHelperService));
            _webHostEnvironment = (IWebHostEnvironment)serviceProvider.GetService(typeof(IWebHostEnvironment));
        }

        protected async Task ImagemService(EnumPastaArquivoIdentificador pasta, IFormFile file, string mensagem, string caminhoImagem = "")
        {
            if (!string.IsNullOrEmpty(caminhoImagem))
                await _helperService.GerarImagem(file, pasta, _webHostEnvironment.WebRootPath, mensagem);           
            else
                await _helperService.AlterarImagem(file, pasta, _webHostEnvironment.WebRootPath, mensagem, caminhoImagem);
        }
    }
}
