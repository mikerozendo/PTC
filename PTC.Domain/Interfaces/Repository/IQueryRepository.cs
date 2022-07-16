using PTC.Domain.Entities;
using System.Threading.Tasks;

namespace PTC.Domain.Interfaces.Repository
{
    public interface IQueryRepository<T> : IBaseQueryRepository<T> where T : Base
    {
        Task<T> ObterPorId(int id);
        Task<bool> Existe(T obj);
    }
}
