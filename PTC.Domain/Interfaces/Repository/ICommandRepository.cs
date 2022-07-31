using PTC.Domain.Entities;
using System.Threading.Tasks;

namespace PTC.Domain.Interfaces.Repository
{
    public interface ICommandRepository<T> where T : Base
    {
        Task<int> Inserir(T obj); //Volta sempre o Id da prop no banco
        Task Deletar(T obj);
        Task Alterar(T obj);
    }
}
