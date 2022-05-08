using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Repository.CQRS
{
    public interface IBaseQueryRepository<T> where T : class
    {
        IEnumerable<T> ObterTodos();
    }
}
