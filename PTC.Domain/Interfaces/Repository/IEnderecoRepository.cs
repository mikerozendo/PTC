using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Repository
{
    public interface IEnderecoRepository
    {
        int Incluir(Endereco obj);
        //Endereco ObterPorIdProprietario(int id);
    }
}
