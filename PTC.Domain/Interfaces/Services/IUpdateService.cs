using PTC.Domain.Entities;
using System.Threading.Tasks;

namespace PTC.Domain.Interfaces.Services
{
    public interface IUpdateService<T> where T : Base 
    {
        Task Alterar(T obj);
    }
}
