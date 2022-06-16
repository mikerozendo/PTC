using System.Threading.Tasks;
using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Services
{
    public interface IBaseGetService<T> where T : class
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<bool> Existe(T obj);
    }
}
