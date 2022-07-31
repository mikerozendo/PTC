using PTC.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace PTC.Domain.Interfaces.Services
{
    public interface IOperacaoService : IBaseService<Operacao>, IBaseGetService<Operacao>
    {
        Task RollBackBuilder(Imagem imageObj = null, Veiculo veiculoObj = null, Operacao operacao = null);
        Task<IEnumerable<Operacao>> ObterPorPeriodo(DateTime dataInicio, DateTime dataTermino);
    }
}
