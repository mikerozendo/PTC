using Microsoft.AspNetCore.Mvc;
using PTC.WEB.Models.Enums;
using PTC.Web.Models.Interfaces.Services;

namespace PTC.WEB.Controllers
{
    public class BaseController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        protected readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly IGeracaoArquivoService _geracaoArquivoService;

        public BaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _webHostEnvironment = (IWebHostEnvironment)GetAppService(typeof(IWebHostEnvironment));
            _geracaoArquivoService = (IGeracaoArquivoService)GetAppService(typeof(IGeracaoArquivoService));
        }

        protected object GetAppService(Type requestedServiceType)
        {
            return _serviceProvider.GetService(requestedServiceType) ?? throw new ArgumentNullException("Erro interno ao requisitar serviços de aplicação");
        }

        protected async Task ImagemService(EnumPastaArquivoIdentificador pasta, IFormFile file, string mensagem, string caminhoImagem = "")
        {
            if (!string.IsNullOrEmpty(caminhoImagem))
                await _geracaoArquivoService.GerarImagem(file, pasta, _webHostEnvironment.WebRootPath, mensagem);
            else
                await _geracaoArquivoService.AlterarImagem(file, pasta, _webHostEnvironment.WebRootPath, mensagem, caminhoImagem);
        }

        protected async Task ImagemService(EnumPastaArquivoIdentificador pasta, List<IFormFile> files, string mensagem, string caminhoImagem = "")
        {
            await _geracaoArquivoService.GerarImagens(files, pasta, _webHostEnvironment.WebRootPath, mensagem);
        }
    }
}
