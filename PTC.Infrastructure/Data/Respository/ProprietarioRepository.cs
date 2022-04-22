using System;
using System.Data;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Domain.Enums;
using PTC.Domain.Interfaces.Repository;
using PTC.Infrastructure.Data.Base;

namespace PTC.Infrastructure.Data.Respository
{
    public class ProprietarioRepository : BaseRepository, IProprietarioRepository
    {
        public bool Existe(Proprietario obj)
        {
            AddParametro("Documento", obj.Documento);
            return ExecutarProcedure("P_PROPRIETARIO_EXISTE").Rows.Count > 0;
        }

        public dynamic Inserir(Proprietario obj)
        {
            AddParametro("Nome", obj.Nome);
            AddParametro("Documento", obj.Documento);
            AddParametro("Email", obj.Email);
            AddParametro("IdEndereco", obj.Endereco.Id);
            AddParametro("WhatsApp", obj.WhatsApp);
            ExecutarProcedure("P_PROPRIETARIO_INCLUIR");
            return "Proprietário Cadastrado com sucesso!";
        }

        public IEnumerable<Proprietario> ObterTodos()
        {
            List<Proprietario> proprietarios = new();
            var tabela = ExecutarProcedure("P_PROPRIETARIO_OBTER_TODOS");

            foreach (DataRow sdr in tabela.Rows)
            {
                proprietarios.Add(new Proprietario
                {
                    Documento = sdr["Documento"].ToString(),
                    Email = sdr["Email"].ToString(),
                    EnumSituacaoProprietario = Convert.ToBoolean(sdr["Ativo"]) ? EnumSituacao.Ativo : EnumSituacao.Inativo,
                    EnumTipoPessoa = (EnumTipoPessoa)sdr["IdTipoPessoa"],
                    Id = Convert.ToInt32(sdr["Id"]),
                    Nome = sdr["Nome"].ToString(),
                    WhatsApp = sdr["WhatsApp"].ToString(),
                    Cadastro = Convert.ToDateTime(sdr["Cadastro"]),
                    Exclusao = sdr["Exclusao"] is DBNull ? null : Convert.ToDateTime(sdr["Exclusao"]),
                    Endereco = new Endereco
                    {
                        Bairro = sdr["Bairro"].ToString(),
                        Cep = sdr["Cep"].ToString(),
                        Logradouro = sdr["Logradouro"].ToString(),
                        Numero = sdr["Numero"].ToString(),
                        Uf = sdr["Uf"].ToString()
                    }
                });
            }

            return proprietarios;
        }

        public void Alterar(Proprietario obj)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Proprietario obj)
        {
            AddParametro("Id", obj.Id);
            ExecutarProcedure("P_PROPRIETARIO_DELETAR");
        }

        public Proprietario ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
