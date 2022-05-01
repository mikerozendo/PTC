using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Services
{
    public interface IEnderecoService : IBaseService<Endereco> 
    {
        void Alterar(Endereco obj);
    }
}
