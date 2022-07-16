using PTC.WEB.Models.Enums;

namespace PTC.Web.Models.Interfaces.Services
{
    public interface IHelperService
    {
        Task GerarImagem(IFormFile arquivos, EnumPastaArquivoIdentificador pasta, string path, string mensagem);
        Task AlterarImagem(IFormFile arquivo, EnumPastaArquivoIdentificador pasta, string path, string mensagem, string caminhoImagem);
        Task GerarImagens(List<IFormFile> arquivos, EnumPastaArquivoIdentificador pasta, string path, string mensagem);
    }
}
