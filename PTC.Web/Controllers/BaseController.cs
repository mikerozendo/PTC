using Microsoft.AspNetCore.Mvc;
using PTC.WEB.Models.Enums;
using PTC.Web.Models.Interfaces.Services;

namespace PTC.WEB.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IServiceProvider _serviceProvider;
        private readonly IGeracaoArquivoService? _geracaoArquivoService;
        protected readonly IWebHostEnvironment? _webHostEnvironment;

        public BaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _geracaoArquivoService = (IGeracaoArquivoService?)serviceProvider.GetService(typeof(IGeracaoArquivoService));
            _webHostEnvironment = (IWebHostEnvironment?)serviceProvider.GetService(typeof(IWebHostEnvironment));
        }

        private IGeracaoArquivoService GeracaoArquivoServiceDecorator
        {
            get
            {
                return _geracaoArquivoService ?? throw new ArgumentNullException("Erro interno ao requisitar serviços de aplicação");
            }
        }

        private IWebHostEnvironment WebHostEnvironmentDecorator
        {
            get
            {
                return _webHostEnvironment ?? throw new ArgumentNullException("Erro interno ao requisitar serviços de aplicação");
            }
        }

        protected async Task ImagemService(EnumPastaArquivoIdentificador pasta, IFormFile file, string mensagem, string caminhoImagem = "")
        {
            if (!string.IsNullOrEmpty(caminhoImagem))
                await GeracaoArquivoServiceDecorator.GerarImagem(file, pasta, WebHostEnvironmentDecorator.WebRootPath, mensagem);
            else
                await GeracaoArquivoServiceDecorator.AlterarImagem(file, pasta, WebHostEnvironmentDecorator.WebRootPath, mensagem, caminhoImagem);
        }

        protected async Task ImagemService(EnumPastaArquivoIdentificador pasta, List<IFormFile> files, string mensagem, string caminhoImagem = "")
        {
            await GeracaoArquivoServiceDecorator.GerarImagens(files, pasta, WebHostEnvironmentDecorator.WebRootPath, mensagem);
        }
    }
}
