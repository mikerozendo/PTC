using PTC.Domain.Entities;
using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Repository
{
    public interface IProprietarioRepository 
    {
        IEnumerable<Proprietario> ObterTodos();
        bool Existe(Proprietario obj);
        void Incluir(Proprietario obj);
    }
}
