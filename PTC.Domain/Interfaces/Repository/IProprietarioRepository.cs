using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Repository
{
    public interface IProprietarioRepository : IQueryRepository<Proprietario>, ICommandRepository<Proprietario> { }
}
