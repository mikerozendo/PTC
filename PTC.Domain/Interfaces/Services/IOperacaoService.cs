using PTC.Domain.Entities;
using System.Threading.Tasks;

namespace PTC.Domain.Interfaces.Services
{
    public interface IOperacaoService : IBaseService<Operacao>, IBaseGetService<Operacao>
    {
        Task RollBackBuilder(bool imageService, bool veiculoService, Imagem imageObj = null, Veiculo veiculoObj = null);
    }
}
