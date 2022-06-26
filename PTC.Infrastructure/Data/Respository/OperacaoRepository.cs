using System.Threading.Tasks;
using PTC.Domain.Entities;
using PTC.Infrastructure.Data.Base;
using PTC.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;

namespace PTC.Infrastructure.Data.Respository
{
    public class OperacaoRepository : BaseRepository, IOperacaoRepository
    {
        public OperacaoRepository(IConfiguration configuration) : base(configuration) { }

        public Task Alterar(Operacao obj)
        {
            return Task.CompletedTask;
        }

        public Task Deletar(Operacao obj)
        {
            return Task.CompletedTask;
        }

        public async Task<dynamic> Inserir(Operacao obj)
        {
            AddParametro("VeiculoId", obj.Veiculo.Id);
            AddParametro("SituacaoAquisicao", obj.EnumSituacaoAquisicao);
            AddParametro("TipoPagamentoAquisicao", obj.EnumTipoPagamentoAquisicao);
            AddParametro("TipoPagamentoRevenda", obj.EnumTipoPagamentoRevenda);
            AddParametro("DataRevenda", obj.DataRevenda);
            AddParametro("Vendido", obj.Vendido);
            AddParametro("ValorCompra", obj.ValorCompra);
            AddParametro("ValorTabela", obj.ValorTabela);
            AddParametro("ValorRevenda", obj.ValorRevenda);
            AddParametro("ProprietarioId", obj.Proprietario.Id);
            AddParametro("CompradorId", obj.Comprador.Id);
            var tabela = await ExecutarProcedureAsync("P_OPERACAO_INSERIR");
            return tabela.Rows.Count;
        }
    }
}
