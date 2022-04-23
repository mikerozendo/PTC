using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using PTC.Infrastructure.Data.Base;

namespace PTC.Infrastructure.Data.Respository
{
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        public dynamic Inserir(Endereco obj)
        {
            AddParametro("@Logradouro", obj.Logradouro);
            AddParametro("@Numero", obj.Numero);
            AddParametro("@Bairro", obj.Bairro);
            AddParametro("@Cep", obj.Cep);
            AddParametro("@Uf", obj.Uf);
            AddParametro("@PontoRefencia", obj.Numero);
            var tabela = ExecutarProcedure("P_ENDERECO_INCLUIR");
            return int.TryParse(tabela.Rows[0]["Id"].ToString(), out int retorno) ? retorno : 0;
        }

        public void Deletar(Endereco obj)
        {
            AddParametro("@Id", obj.Id);
            ExecutarProcedure("P_ENDERECO_EXCLUIR_POR_ID");
        }

        public void Alterar(Endereco obj)
        {
            AddParametro("Logradouro", obj.Logradouro);
            AddParametro("Bairro", obj.Bairro);
            AddParametro("Numero", obj.Numero);
            AddParametro("Cep", obj.Cep);
            AddParametro("Uf", obj.Uf);
            AddParametro("PontoReferencia", obj.PontoReferencia);
            AddParametro("ProprietarioId", obj.ProprietarioId);
            ExecutarProcedure("P_ENDERECO_ALTERAR");
        }
    }
}
