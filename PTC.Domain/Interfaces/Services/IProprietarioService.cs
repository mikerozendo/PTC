using System;
using System.Collections.Generic;
using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Services
{
    public interface IProprietarioService : IBaseService<Proprietario>, IBaseGetService<Proprietario>
    {
        //IEnumerable<Proprietario> ObterFiltrados(DateTime? inicio, DateTime? termino);
        IEnumerable<Proprietario> Filtrar(string filtro);
        string Alterar(Proprietario obj);
    }
}
