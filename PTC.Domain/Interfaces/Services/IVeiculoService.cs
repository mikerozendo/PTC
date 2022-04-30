using PTC.Domain.Entities;
using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Services
{
    public interface IVeiculoService
    {
        IEnumerable<Veiculo> Inserir(Veiculo obj);
        Veiculo ObterPorIdProprietario(int id);
        void Deletar(Veiculo obj);
        void Alterar(Veiculo obj);
    }
}
