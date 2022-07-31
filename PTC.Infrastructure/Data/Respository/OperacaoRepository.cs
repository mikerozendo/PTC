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

        public async Task<int> Inserir(Operacao obj)
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

            int.TryParse(tabela.Rows[0]["IdOperacao"].ToString(), out int idOperacao);
            return idOperacao;
        }

        public Task<IEnumerable<Operacao>> ObterPorPeriodo(DateTime dataInicio, DateTime dataTermino)
        {
            //falta montar query obter por periodo, descontinuar obtertodos e alterar estrutura de codigo base de servicos e repositorio
            throw new NotImplementedException();
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
                    DataRevenda = sdr["DataRevenda"] is DBNull ? new DateTime().Date : (DateTime)sdr["DataRevenda"],
                    EnumSituacaoAquisicao = (EnumSituacaoAquisicao)(int)sdr["SituacaoAquisicao"],
                    EnumTipoPagamentoAquisicao = (EnumFormaPagamento)(int)sdr["TipoPagamentoAquisicao"],
                    EnumTipoPagamentoRevenda = (EnumFormaPagamento)(int)sdr["TipoPagamentoRevenda"],
                    Proprietario = new Proprietario
                    {
                        Id = sdr["ProprietarioId"] is DBNull ? 0 : Convert.ToInt32(sdr["ProprietarioId"].ToString()),
                        Nome = sdr["ProprietarioId"] is DBNull ? String.Empty : (string)sdr["NomeProprietario"]
                    },
                    Comprador = new Proprietario
                    {
                        Id = Convert.ToInt32(sdr["CompradorId"]),
                        Nome = (string)sdr["NomeComprador"]
                    },
                    Veiculo = new Veiculo
                    {
                        Id = (int)sdr["VeiculoId"],
                        Nome = (string)sdr["NomeVeiculo"],
                        Modelo = (string)sdr["ModeloVeiculo"],
                        Km = (decimal)sdr["Km"],
                        CaminhoImagem = sdr["CaminhoImagem"] is DBNull ? String.Empty : (string)sdr["CaminhoImagem"],
                        MarcaVeiculo = new Marca
                        {
                            Id = Convert.ToInt32(sdr["MarcaVeiculoId"])
                        }
                    },
                    ValorCompra = (decimal)sdr["ValorCompra"],
                    ValorRevenda = (decimal)sdr["ValorRevenda"]
                });
            }

            return list;
        }
    }
}
