using System;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using PTC.Infrastructure.Data.Base;

namespace PTC.Infrastructure.Data.Respository
{
    public class ProprietarioRepository : BaseRepository, IProprietarioRepository
    {
        public bool Existe(Proprietario obj)
        {
            AddParametro("Nome", obj.Nome);
            AddParametro("Documento", obj.Documento);
            return ExecutarProcedure("P_PROPRIETARIO_EXISTE").Rows.Count > 0;
        }

        public string Inserir(Proprietario obj)
        {
            AddParametro("Nome", obj.Nome);
            AddParametro("Documento", obj.Documento);
            AddParametro("Email", obj.Email);
            AddParametro("IdEndereco", obj.Endereco.Id);
            AddParametro("WhatsApp", obj.WhatsApp);
            ExecutarProcedure("P_PROPRIETARIO_INCLUIR");
            return string.Empty;
        }
        public void Alterar(Proprietario obj)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Proprietario obj)
        {
            throw new NotImplementedException();
        }

        public Proprietario ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Proprietario> ObterPorPeriodoCadastro(DateTime inicio, DateTime termino)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Proprietario> ObterTodos()
        {
            throw new NotImplementedException();

            //List<Proprietario> proprietarios = new();
            //var tabela = ExecutarProcedure("P_PROPRIETARIO_OBTER_TODOS");

            //foreach (DataRow sdr in tabela.Rows)
            //{
            //    proprietarios.Add(new Proprietario
            //    {
            //        Documento = sdr["Documento"].ToString(),
            //        Email = sdr["Email"].ToString(),
            //        EnumSituacaoProprietario = (EnumSituacao)sdr["Situacao"],
            //        EnumTipoPessoa = (EnumTipoPessoa)sdr["TipoPessoa"],
            //        Id = Convert.ToInt32(sdr["Id"]),
            //        Nome = sdr["Nome"].ToString(),
            //        WhatsApp = sdr["WhatsApp"].ToString(),
            //        Endereco = new Endereco
            //        {
            //            Bairro = sdr["Bairro"].ToString(),
            //            Cep = sdr["Cep"].ToString(),
            //            Logradouro = sdr["Logradouro"].ToString(),
            //            Numero = sdr["Logradouro"].ToString(),
            //            Uf = sdr["Uf"].ToString()
            //        }
            //    });
            //}

            //return proprietarios;
        }
    }
}
