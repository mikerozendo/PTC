using PTC.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Repository.CQRS
{
    public interface IBaseQueryRepository<T> where T : Base
    {
        Task<IEnumerable<T>> ObterTodos();
    }
}
