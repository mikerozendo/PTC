using System.Threading.Tasks;
using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Services
{
    public interface IVeiculosService : IBaseService<Veiculo>, IBaseGetService<Veiculo>
    {
        Task Alterar(Veiculo obj);
    }
}
