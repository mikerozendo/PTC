using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Repository.CQRS
{
    public interface IQueryRepository<T> : IBaseQueryRepository<T>
    {
        T ObterPorId(int id);
        bool Existe(T obj);
    }
}
