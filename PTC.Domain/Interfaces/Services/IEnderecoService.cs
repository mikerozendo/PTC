using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Services
{
    public  interface IEnderecoService
    {
        int Incluir(Endereco obj);
        Endereco ObterPorIdProprietario(int id);
    }
}
