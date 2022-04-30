using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Repository.CQRS
{
    public interface IBaseQueryRepository<T>
    {
        IEnumerable<T> ObterTodos();
    }
}
