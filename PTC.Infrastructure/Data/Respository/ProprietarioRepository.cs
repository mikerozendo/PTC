using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using PTC.Infrastructure.Data.Base;
using Microsoft.Extensions.Configuration;

namespace PTC.Infrastructure.Data.Respository
{
    public class ProprietarioRepository : BaseRepository, IProprietarioRepository
    {
        public ProprietarioRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<bool> Existe(Proprietario obj)
        {
            AddParametro("Documento", obj.Documento.Numero);
            var response = await ExecutarProcedureAsync("P_PROPRIETARIO_EXISTE");
            return response.Rows.Count > 0;
        }

        public async Task<int> Inserir(Proprietario obj)
        {
            try
            {
                AddParametro("Nome", obj.Nome);
                AddParametro("Documento", obj.Documento.Numero);
                AddParametro("Email", obj.Email);
                AddParametro("IdEndereco", obj.Endereco.Id);
                AddParametro("WhatsApp", obj.WhatsApp);
                AddParametro("IdTipoPessoa", (int)obj.EnumTipoPessoa);

                var tabela = await ExecutarProcedureAsync("P_PROPRIETARIO_INCLUIR");

                return int.TryParse(tabela.Rows[0]["IdProprietario"].ToString(), out int retorno) ? retorno : 0;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<IEnumerable<Proprietario>> ObterTodos()
        {
            List<Proprietario> proprietarios = new();
            var tabela = await ExecutarProcedureAsync("P_PROPRIETARIO_OBTER_TODOS");

            foreach (DataRow sdr in tabela.Rows)
            {
                proprietarios.Add(new(sdr["Documento"].ToString())
                {
                    Email = sdr["Email"].ToString(),
                    Id = Convert.ToInt32(sdr["Id"]),
                    Nome = sdr["Nome"].ToString(),
                    WhatsApp = sdr["WhatsApp"].ToString(),
                    Cadastro = Convert.ToDateTime(sdr["Cadastro"]),
                    CaminhoImagem = sdr["CaminhoImagem"] is DBNull ? null : sdr["CaminhoImagem"].ToString(),
                    Endereco = new Endereco
                    {
                        Bairro = sdr["Bairro"].ToString(),
                        Cep = sdr["Cep"].ToString(),
                        Logradouro = sdr["Logradouro"].ToString(),
                        Numero = sdr["Numero"].ToString(),
                        Uf = sdr["Uf"].ToString(),
                        Cidade = sdr["Cidade"].ToString(),
                        PontoReferencia = sdr["PontoReferencia"].ToString()
                    }
                });
            }

            return proprietarios;
        }

        public async Task Alterar(Proprietario obj)
        {
            AddParametro("Id", obj.Id);
            AddParametro("Nome", obj.Nome);
            AddParametro("Documento", obj.Documento.Numero);
            AddParametro("Email", obj.Email);
            AddParametro("WhatsApp", obj.WhatsApp);
            AddParametro("CaminhoImagem", obj.CaminhoImagem);
            await ExecutarProcedureAsync("P_PROPRIETARIO_ALTERAR");
        }

        public async Task Deletar(Proprietario obj)
        {
            AddParametro("Id", obj.Id);
            await ExecutarProcedureAsync("P_PROPRIETARIO_DELETAR");
        }

        public async Task<Proprietario> ObterPorId(int id)
        {
            AddParametro("Id", id);
            var tabela = await ExecutarProcedureAsync("P_PROPRIETARIO_OBTER_POR_ID");

            if (tabela.Rows.Count > 0)
            {
                return new(tabela.Rows[0]["Documento"].ToString())
                {
                    Email = tabela.Rows[0]["Email"].ToString(),
                    Id = Convert.ToInt32(tabela.Rows[0]["Id"]),
                    Nome = tabela.Rows[0]["Nome"].ToString(),
                    WhatsApp = tabela.Rows[0]["WhatsApp"].ToString(),
                    Cadastro = Convert.ToDateTime(tabela.Rows[0]["Cadastro"]),
                    CaminhoImagem = tabela.Rows[0]["CaminhoImagem"].ToString(),
                    Endereco = new Endereco
                    {
                        Bairro = tabela.Rows[0]["Bairro"].ToString(),
                        Cep = tabela.Rows[0]["Cep"].ToString(),
                        Logradouro = tabela.Rows[0]["Logradouro"].ToString(),
                        Numero = tabela.Rows[0]["Numero"].ToString(),
                        Uf = tabela.Rows[0]["Uf"].ToString(),
                        Cidade = tabela.Rows[0]["Cidade"].ToString(),
                        PontoReferencia = tabela.Rows[0]["PontoReferencia"].ToString()
                    }
                };
            }

            else return null;          
        }

        public async Task<IEnumerable<Proprietario>> ObterPorPeriodo(DateTime dataInicio, DateTime dataTermino)
        {
            AddParametro("@DataInicio", dataInicio);
            AddParametro("@DataTermino", dataTermino);

            List<Proprietario> proprietarios = new();
            var tabela = await ExecutarProcedureAsync("P_PROPRIETARIO_OBTER_POR_PERIODO");

            foreach (DataRow sdr in tabela.Rows)
            {
                proprietarios.Add(new(sdr["Documento"].ToString())
                {
                    Email = sdr["Email"].ToString(),
                    Id = Convert.ToInt32(sdr["Id"]),
                    Nome = sdr["Nome"].ToString(),
                    WhatsApp = sdr["WhatsApp"].ToString(),
                    Cadastro = Convert.ToDateTime(sdr["Cadastro"]),
                    CaminhoImagem = sdr["CaminhoImagem"].ToString(),
                    Endereco = new Endereco
                    {
                        Bairro = sdr["Bairro"].ToString(),
                        Cep = sdr["Cep"].ToString(),
                        Logradouro = sdr["Logradouro"].ToString(),
                        Numero = sdr["Numero"].ToString(),
                        Uf = sdr["Uf"].ToString(),
                        Cidade = sdr["Cidade"].ToString(),
                        PontoReferencia = sdr["PontoReferencia"].ToString()
                    }
                });
            }

            return proprietarios;
        }

        public async Task<bool> PossuiOperacao(int proprietarioId)
        {
            AddParametro("IdProprietario", proprietarioId);
            var tabela = await ExecutarProcedureAsync("P_PROPRIETARIO_POSSUI_OPERACAO");

            if (tabela.Rows.Count > 0) return true;

            return false;
        }
    }
}
