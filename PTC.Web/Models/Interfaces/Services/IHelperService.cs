using PTC.WEB.Models.Enums;

namespace PTC.Web.Models.Interfaces.Services
{
    public interface IHelperService
    {
        Task GerarImagem(IFormFile arquivo, EnumPastaArquivoIdentificador pasta, string caminho, string mensagem);
        Task AlterarImagem(IFormFile arquivo, EnumPastaArquivoIdentificador pasta, string path, string mensagem, string caminhoImagem);
    }
}
