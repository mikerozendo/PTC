using System.Threading.Tasks;
using PTC.Domain.Entities;
using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Services
{
    public interface IOperacaoService : IBaseService<Operacao>, IBaseGetService<Operacao>
    {
        Task<List<string>> InserirImagemDecorator(Imagem imagem);
    }
}
