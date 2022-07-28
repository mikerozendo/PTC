using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Repository
{
    public interface IOperacaoRepository : ICommandRepository<Operacao>, IBaseQueryRepository<Operacao> { }
}
