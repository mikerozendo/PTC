using PTC.Domain.Entities;
using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Services
{
    public interface IMarcasService
    {
        void Deletar(Marca obj);
        IEnumerable<Marca> Inserir(Marca obj);
    }
}
