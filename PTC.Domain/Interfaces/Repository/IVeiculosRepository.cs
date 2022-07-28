using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Repository
{
    public interface IVeiculosRepository : ICommandRepository<Veiculo>, IBaseQueryRepository<Veiculo> { }
}
