using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository.CQRS;

namespace PTC.Domain.Interfaces.Repository
{
    public interface IProprietarioRepository : IQueryRepository<Proprietario>, ICommandRepository<Proprietario> { }
}
