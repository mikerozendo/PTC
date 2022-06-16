using System;
using System.Threading.Tasks;
using PTC.Domain.Entities;
using PTC.Infrastructure.Data.Base;
using PTC.Domain.Interfaces.Repository;

namespace PTC.Infrastructure.Data.Respository
{
    public class OperacaoRepository : BaseRepository, IOperacaoRepository
    {
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
            AddParametro("IdVeiculo", obj.Veiculo.Id);
            AddParametro("IdProprietario", obj.Proprietario.Id);
            AddParametro("IdComprador", obj.Comprador.Id);
            AddParametro("SituacaoAquisicao", obj.EnumSituacaoAquisicao);
            AddParametro("FormaPagamentoAquisicao", obj.EnumTipoPagamentoAquisicao);
            AddParametro("FormaPagamentoRevenda", obj.EnumTipoPagamentoRevenda);
            AddParametro("Compra", obj.Cadastro);
            AddParametro("Revenda", obj.DataRevenda);
            AddParametro("Cadastro", DateTime.Now);
            var tabela = await ExecutarProcedureAsync("P_OPERACAO_INSERIR");
            return tabela.Rows.Count;
        }
    }
}
