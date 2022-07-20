using PTC.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Services
{
    public interface IImagemService : IBaseService<Imagem>, IUpdateService<Imagem> 
    {
        Task<List<string>> ObterImagensVeiculosPorIdOperacao(int idOperacao, bool download);
        Task<int> InserirImagemProprietario(Imagem obj);
    }
}
