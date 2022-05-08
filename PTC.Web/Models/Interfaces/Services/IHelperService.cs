using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PTC.Web.Models.Interfaces.Services
{
    public interface IHelperService
    {
        Task GerarImagemProprietario(IFormFile arquivo, string caminho, string mensagem);
    }
}
