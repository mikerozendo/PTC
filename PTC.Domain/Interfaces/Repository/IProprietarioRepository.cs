using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Repository
{
    public interface IProprietarioRepository : IQueryRepository<Proprietario>, ICommandRepository<Proprietario> 
    {
        Task<IEnumerable<Proprietario>> ObterPorPeriodo(DateTime dataInicio, DateTime dataCadastro);
    }
}
