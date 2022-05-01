using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Services
{
    public interface IBaseGetService<T> where T : class
    {
        IEnumerable<T> ObterTodos();
        bool Existe(T obj);
    }
}
