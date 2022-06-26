using System.Threading.Tasks;
using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Services
{
    public interface IEnderecoService : IBaseService<Endereco> 
    {
        Task Alterar(Endereco obj);
    }
}
