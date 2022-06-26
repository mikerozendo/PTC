using System.Threading.Tasks;
using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Services
{
    public interface IMarcasService : IBaseService<Marca>, IBaseGetService<Marca>
    {
        Task Alterar(Marca obj);
    }
}
