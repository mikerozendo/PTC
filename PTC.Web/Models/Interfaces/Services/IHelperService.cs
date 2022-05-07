using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PTC.Domain.Entities;

namespace PTC.Web.Models.Interfaces.Services
{
    public interface IHelperService
    {
        Task<Imagem> GerarImagemProprietario(IFormFile arquivo, string caminho);
        void DeletarImagem(string path, string imagem, string mensagemInsert);
    }
}
