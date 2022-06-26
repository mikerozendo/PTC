using System.Threading.Tasks;
using System.Collections.Generic;
using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Services
{
    public interface IProprietarioService : IBaseService<Proprietario>, IBaseGetService<Proprietario>
    {
        Task<IEnumerable<Proprietario>> Filtrar(string filtro);
        Task<string> Alterar(Proprietario obj);
    }
}
