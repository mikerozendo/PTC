using System;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Domain.Enums;

namespace PTC.Domain.Interfaces.Services
{
    public interface IProprietarioService : IBaseService<Proprietario>, IBaseGetService<Proprietario>
    {
        IEnumerable<Proprietario> ObterFiltrados(DateTime? inicio, DateTime? termino, EnumSituacao situacao);
        IEnumerable<Proprietario> Filtrar(string filtro);
        string Alterar(Proprietario obj);
    }
}
