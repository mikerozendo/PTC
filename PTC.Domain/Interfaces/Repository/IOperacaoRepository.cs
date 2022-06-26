using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository.CQRS;

namespace PTC.Domain.Interfaces.Repository
{
    public interface IOperacaoRepository : ICommandRepository<Operacao>, IBaseQueryRepository<Operacao> { }
}
