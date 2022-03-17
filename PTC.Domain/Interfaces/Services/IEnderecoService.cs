using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Services
{
    public  interface IEnderecoService
    {
        int Incluir(Endereco obj);
        int ExcluirPorId(int id);
        Endereco ObterPorIdProprietario(int id);
    }
}
