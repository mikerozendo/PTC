using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Repository
{
    public interface IMarcasRepository : IQueryRepository<Marca>, ICommandRepository<Marca> { }
}
