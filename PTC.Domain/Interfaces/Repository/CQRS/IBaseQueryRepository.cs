using System.Threading.Tasks;
using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Repository.CQRS
{
    public interface IBaseQueryRepository<T> where T : class
    {
        Task<IEnumerable<T>> ObterTodos();
    }
}
