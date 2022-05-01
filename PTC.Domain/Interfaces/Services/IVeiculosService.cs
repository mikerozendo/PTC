using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Services
{
    public interface IVeiculosService : IBaseService<Veiculo>, IBaseGetService<Veiculo>
    {
        void Alterar(Veiculo obj);
    }
}
