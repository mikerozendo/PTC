using PTC.Domain.Entities;
using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Services
{
    public interface IVeiculoService
    {
        IEnumerable<Veiculo> ObterTodos();
        string Inserir(Veiculo obj);
        Veiculo ObterPorIdProprietario(int id);
        void Deletar(Veiculo obj);
        void Alterar(Veiculo obj);
        string ObterPorId(int id);
    }
}
