using System.Threading.Tasks;
using System.Collections.Generic;
using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Services
{
    public interface IBaseGetService<T> where T : Base
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<bool> Existe(T obj);
    }
}
