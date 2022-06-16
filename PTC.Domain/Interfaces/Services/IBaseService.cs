using System.Threading.Tasks;

namespace PTC.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<dynamic> Inserir(T obj);
        Task Deletar(T obj);
        Task<T> ObterPorId(int id);
    }
}
