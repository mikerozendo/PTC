using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PTC.Domain.Enums;
using PTC.Domain.Entities;
using PTC.Infrastructure.Data.Base;
using PTC.Domain.Interfaces.Repository;
using System.IO;

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

        public Task<bool> Existe(Operacao obj)
        {
            throw new NotImplementedException();
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

        public async Task<Operacao> ObterPorId(int id)
        {
            AddParametro("Id", id);
            var tabela = await ExecutarProcedureAsync("P_OPERACAO_OBTER_POR_ID");

            return new Operacao
            {
                Id = (int)tabela.Rows[0]["Id"],
                Cadastro = (DateTime)tabela.Rows[0]["DataCadastro"],
                DataRevenda = tabela.Rows[0]["DataRevenda"] is DBNull ? new DateTime().Date : (DateTime)tabela.Rows[0]["DataRevenda"],
                EnumSituacaoAquisicao = (EnumSituacaoAquisicao)(int)tabela.Rows[0]["SituacaoAquisicao"],
                EnumTipoPagamentoAquisicao = (EnumFormaPagamento)(int)tabela.Rows[0]["TipoPagamentoAquisicao"],
                EnumTipoPagamentoRevenda = (EnumFormaPagamento)(int)tabela.Rows[0]["TipoPagamentoRevenda"],
                Proprietario = new()
                {
                    Id = Convert.ToInt32(tabela.Rows[0]["ProprietarioId"].ToString()),
                    Nome = (string)tabela.Rows[0]["NomeProprietario"],
                    Documento = new(tabela.Rows[0]["DocumentoProprietario"].ToString())
                },
                Comprador = new()
                {
                    Id = Convert.ToInt32(tabela.Rows[0]["CompradorId"]),
                    Nome = (string)tabela.Rows[0]["NomeComprador"],
                },
                Veiculo = new Veiculo
                {
                    Id = (int)tabela.Rows[0]["VeiculoId"],
                    Nome = (string)tabela.Rows[0]["NomeVeiculo"],
                    Modelo = (string)tabela.Rows[0]["ModeloVeiculo"],
                    Km = (decimal)tabela.Rows[0]["Km"],
                    CaminhoImagem = (string)tabela.Rows[0]["CaminhoImagem"],
                    MarcaVeiculo = new Marca
                    {
                        Id = Convert.ToInt32(tabela.Rows[0]["MarcaVeiculoId"])
                    }
                },
                ValorCompra = (decimal)tabela.Rows[0]["ValorCompra"],
                ValorRevenda = (decimal)tabela.Rows[0]["ValorRevenda"],
                ValorTabela = (decimal)tabela.Rows[0]["ValorTabela"]
            };
        }

        public async Task<IEnumerable<Operacao>> ObterPorPeriodo(DateTime dataInicio, DateTime dataTermino)
        {
            List<Operacao> list = new();
            AddParametro("DataInicio", dataInicio);
            AddParametro("DataTermino", dataTermino);

            var tabela = await ExecutarProcedureAsync("P_OPERACAO_OBTER_POR_PERIODO");

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
                    Proprietario = new()
                    {
                        Id = Convert.ToInt32(sdr["ProprietarioId"].ToString()),
                        Nome = (string)sdr["NomeProprietario"],
                        Documento = new(sdr["DocumentoProprietario"].ToString())
                    },
                    Comprador = new()
                    {
                        Id = Convert.ToInt32(sdr["CompradorId"]),
                        Nome = (string)sdr["NomeComprador"],
                        //Nem toda operacao começa com um comprador cadastrado, o que pode lançar um exception
                        // uma vez que a procedure pega o comprador por leftjoin
                        //Documento = new(sdr["DocumentoComprador"].ToString()) 
                    },
                    Veiculo = new Veiculo
                    {
                        Id = (int)sdr["VeiculoId"],
                        Nome = (string)sdr["NomeVeiculo"],
                        Modelo = (string)sdr["ModeloVeiculo"],
                        Km = (decimal)sdr["Km"],
                        CaminhoImagem = (string)sdr["CaminhoImagem"],
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
