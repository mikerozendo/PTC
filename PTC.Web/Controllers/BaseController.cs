using Microsoft.AspNetCore.Mvc;
using PTC.WEB.Models.Enums;
using PTC.Web.Models.Interfaces.Services;

namespace PTC.WEB.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IServiceProvider _serviceProvider;
        private readonly IHelperService _helperService;
        protected readonly IWebHostEnvironment _webHostEnvironment;


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

        protected async Task ImagemService(EnumPastaArquivoIdentificador pasta, List<IFormFile> files, string mensagem, string caminhoImagem = "")
        {
            await _helperService.GerarImagens(files, pasta, _webHostEnvironment.WebRootPath, mensagem);
        }
    }
}
