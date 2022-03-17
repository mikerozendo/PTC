using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Repository
{
    public interface IEnderecoRepository
    {
        int Incluir(Endereco obj);
        int ExcluirPorId(int id);
        Endereco ObterPorIdProprietario(int id);
    }
}
