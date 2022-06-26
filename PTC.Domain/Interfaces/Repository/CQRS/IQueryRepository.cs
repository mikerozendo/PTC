using System.Threading.Tasks;

namespace PTC.Domain.Interfaces.Repository.CQRS
{
    public interface IQueryRepository<T> : IBaseQueryRepository<T> where T : class
    {
        Task<T> ObterPorId(int id);
        Task<bool> Existe(T obj);
    }
}
