using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Services
{
    public interface IEnderecoService
    {
        int Inserir(Endereco obj);
        Endereco ObterPorIdProprietario(int id);
        void Deletar(Endereco obj);
        void Alterar(Endereco obj);
    }
}
