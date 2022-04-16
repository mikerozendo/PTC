using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using System;
using System.Data;

namespace PTC.Infrastructure.Data
{
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        public int Incluir(Endereco obj)
        {
            AddParametro("@Logradouro", obj.Logradouro);
            AddParametro("@Numero",  obj.Numero);
            AddParametro("@Bairro",obj.Bairro);
            AddParametro("@Cep",obj.Cep);
            AddParametro("@Uf",  obj.Uf);
            AddParametro("@PontoRefencia",obj.Numero);

            var tabela = ExecutarProcedure("P_ENDERECO_INCLUIR");
            return tabela.Rows[0]["Id"] is DBNull ? 0 : Convert.ToInt32(tabela.Rows[0]["Id"]);
        }

        //public int ExcluirPorId(int id)
        //{
        //    AddParametro("@Id", SqlDbType.VarChar, id);
        //    ExecutarProcedure("P_ENDERECO_EXCLUIR_POR_ID");
        //    return id;
        //}

        //public Endereco ObterPorIdProprietario(int id)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
