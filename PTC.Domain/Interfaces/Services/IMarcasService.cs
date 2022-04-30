using PTC.Domain.Entities;
using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Services
{
    public interface IMarcasService
    {
        IEnumerable<Marca> ObterTodos();
        Marca ObterPorId(int id);
        bool Existe(Marca obj);
        void Deletar(Marca obj);
        string Inserir(Marca obj);
        void Alterar(Marca obj);
    }
}
