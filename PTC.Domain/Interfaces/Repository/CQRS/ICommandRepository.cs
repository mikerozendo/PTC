using System.Threading.Tasks;

namespace PTC.Domain.Interfaces.Repository.CQRS
{
    public interface ICommandRepository<T> where T : class
    {
        Task<dynamic> Inserir(T obj);
        Task Deletar(T obj);
        Task Alterar(T obj);
    }
}
