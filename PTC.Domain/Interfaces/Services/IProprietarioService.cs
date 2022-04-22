using System;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Domain.Enums;

namespace PTC.Domain.Interfaces.Services
{
    public interface IProprietarioService
    {
        string Inserir(Proprietario proprietario);
        bool Existe(Proprietario proprietario);
        IEnumerable<Proprietario> ObterTodos();
        IEnumerable<Proprietario> ObterFiltrados(DateTime? inicio, DateTime? termino, EnumSituacao situacao);
    }
}
