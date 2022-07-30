using PTC.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTC.Domain.Interfaces.Repository
{
    public interface IOperacaoRepository : ICommandRepository<Operacao>, IBaseQueryRepository<Operacao> 
    {
    }
}
