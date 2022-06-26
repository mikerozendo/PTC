using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PTC.Domain.Enums;
using PTC.Domain.Entities;
using PTC.Infrastructure.Data.Base;
using PTC.Domain.Interfaces.Repository;

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

        public async Task<IEnumerable<Operacao>> ObterTodos()
        {
            List<Operacao> list = new();
            var tabela = await ExecutarProcedureAsync("P_OPERACAO_OBTER");

            foreach (DataRow sdr in tabela.Rows)
            {
                list.Add(new Operacao
                {
                    Id = (int)sdr["Id"],
                    Cadastro = (DateTime)sdr["DataCadastro"],
                    DataRevenda = (DateTime)sdr["DataRevenda"],
                    EnumSituacaoAquisicao = (EnumSituacaoAquisicao)sdr["SituacaoAquisicao"],
                    EnumTipoPagamentoAquisicao = (EnumFormaPagamento)sdr["TipoPagamentoAquisicao"],
                    EnumTipoPagamentoRevenda = (EnumFormaPagamento)sdr["TipoPagamentoRevenda"],
                    Proprietario = new Proprietario
                    {
                        Id = (int)sdr["ProprietarioId"],
                        Nome = (string)sdr["NomeProprietario"]
                    },
                    Veiculo = new Veiculo
                    {
                        Id = (int)sdr["VeiculoId"],
                        Nome = (string)sdr["NomeVeiculo"],
                        Modelo = (string)sdr["ModeloVeiculo"]
                    },
                    ValorCompra = (decimal)sdr["ValorCompra"],
                    Comprador = new Proprietario
                    {
                        Id = (int)sdr["CompradorId"],
                        Nome = (string)sdr["NomeComprador"]
                    },      
                });
            }

            return list;
        }
    }
}
