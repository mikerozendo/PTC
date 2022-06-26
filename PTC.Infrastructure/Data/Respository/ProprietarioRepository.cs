using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Domain.Enums;
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
            AddParametro("Documento", obj.Documento);
            var response = await ExecutarProcedureAsync("P_PROPRIETARIO_EXISTE");
            return response.Rows.Count > 0;
        }

        public async Task<dynamic> Inserir(Proprietario obj)
        {
            AddParametro("Nome", obj.Nome);
            AddParametro("Documento", obj.Documento);
            AddParametro("Email", obj.Email);
            AddParametro("IdEndereco", obj.Endereco.Id);
            AddParametro("WhatsApp", obj.WhatsApp);
            AddParametro("CaminhoImagem", obj.CaminhoImagem);
            await ExecutarProcedureAsync("P_PROPRIETARIO_INCLUIR");
            return "Proprietário Cadastrado com sucesso!";
        }

        public async Task<IEnumerable<Proprietario>> ObterTodos()
        {
            List<Proprietario> proprietarios = new();
            var tabela = await ExecutarProcedureAsync("P_PROPRIETARIO_OBTER_TODOS");

            foreach (DataRow sdr in tabela.Rows)
            {
                proprietarios.Add(new Proprietario
                {
                    Documento = sdr["Documento"].ToString(),
                    Email = sdr["Email"].ToString(),
                    EnumTipoPessoa = (EnumTipoPessoa)sdr["IdTipoPessoa"],
                    Id = Convert.ToInt32(sdr["Id"]),
                    Nome = sdr["Nome"].ToString(),
                    WhatsApp = sdr["WhatsApp"].ToString(),
                    Cadastro = Convert.ToDateTime(sdr["Cadastro"]),
                    Exclusao = sdr["Exclusao"] is DBNull ? null : Convert.ToDateTime(sdr["Exclusao"]),
                    CaminhoImagem = sdr["CaminhoImagem"] is DBNull ? null : sdr["CaminhoImagem"].ToString(),
                    Endereco = new Endereco
                    {
                        Bairro = sdr["Bairro"].ToString(),
                        Cep = sdr["Cep"].ToString(),
                        Logradouro = sdr["Logradouro"].ToString(),
                        Numero = sdr["Numero"].ToString(),
                        Uf = sdr["Uf"].ToString(),
                        Cidade = sdr["Cidade"].ToString()                        
                    }
                });
            }

            return proprietarios;
        }

        public async Task Alterar(Proprietario obj)
        {
            AddParametro("Id", obj.Id);
            AddParametro("Nome", obj.Nome);
            AddParametro("Documento", obj.Documento);
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

            return new Proprietario
            {
                Documento = tabela.Rows[0]["Documento"].ToString(),
                Email = tabela.Rows[0]["Email"].ToString(),
                EnumTipoPessoa = (EnumTipoPessoa)tabela.Rows[0]["IdTipoPessoa"],
                Id = Convert.ToInt32(tabela.Rows[0]["Id"]),
                Nome = tabela.Rows[0]["Nome"].ToString(),
                WhatsApp = tabela.Rows[0]["WhatsApp"].ToString(),
                Cadastro = Convert.ToDateTime(tabela.Rows[0]["Cadastro"]),
                Exclusao = tabela.Rows[0]["Exclusao"] is DBNull ? null : Convert.ToDateTime(tabela.Rows[0]["Exclusao"]),
                CaminhoImagem = tabela.Rows[0]["CaminhoImagem"] is DBNull ? null : tabela.Rows[0]["CaminhoImagem"].ToString(),
                Endereco = new Endereco
                {
                    Bairro = tabela.Rows[0]["Bairro"].ToString(),
                    Cep = tabela.Rows[0]["Cep"].ToString(),
                    Logradouro = tabela.Rows[0]["Logradouro"].ToString(),
                    Numero = tabela.Rows[0]["Numero"].ToString(),
                    Uf = tabela.Rows[0]["Uf"].ToString(),
                    Cidade = tabela.Rows[0]["Cidade"].ToString(),
                }
            };
        }
    }
}
