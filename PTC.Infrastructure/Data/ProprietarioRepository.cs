using PTC.Domain.Entities;
using PTC.Domain.Enums;
using PTC.Domain.Interfaces.Repository;
using PTC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace PTC.Infrastructure.Data
{
    public class ProprietarioRepository : BaseRepository, IProprietarioRepository
    {
        public bool Existe(Proprietario obj)
        {
            AddParametro("@Nome", SqlDbType.VarChar, obj.Nome);
            AddParametro("@Documento", SqlDbType.VarChar, obj.Documento);

            return ExecutarProcedure("P_PROPRIETARIO_EXISTE").Rows.Count > 0;
        }

        public void Incluir(Proprietario obj)
        {
            AddParametro("@Id", SqlDbType.Int, obj.Id);
            AddParametro("@Nome", SqlDbType.VarChar, obj.Nome);
            AddParametro("@Documento", SqlDbType.VarChar, obj.Documento);
            AddParametro("@Email", SqlDbType.VarChar, obj.Email);
            AddParametro("@SituacaoProprietario", SqlDbType.Int, (int)obj.EnumSituacaoProprietario);
            AddParametro("@EnumTipoPessoa", SqlDbType.Int, (int)obj.EnumTipoPessoa);

            ExecutarProcedure("P_PROPRIETARIO_INCLUIR");
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
                    EnumSituacaoProprietario = (EnumSituacao)sdr["Situacao"],
                    EnumTipoPessoa = (EnumTipoPessoa)sdr["TipoPessoa"],
                    Id = Convert.ToInt32(sdr["Id"]),
                    Nome = sdr["Nome"].ToString(),
                    WhatsApp = sdr["WhatsApp"].ToString(),
                    Endereco = new Endereco
                    {
                        Bairro = sdr["Bairro"].ToString(),
                        Cep = sdr["Cep"].ToString(),
                        Logradouro = sdr["Logradouro"].ToString(),
                        Numero = sdr["Logradouro"].ToString(),
                        Uf = sdr["Uf"].ToString()
                    }
                });
            }

            return proprietarios;
        }
    }
}
