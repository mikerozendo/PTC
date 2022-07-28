using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PTC.Domain.Entities;
using PTC.Infrastructure.Data.Base;
using PTC.Domain.Interfaces.Repository;

namespace PTC.Infrastructure.Data.Respository
{
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        public EnderecoRepository(IConfiguration configuration) : base(configuration){ }
        public async Task<int> Inserir(Endereco obj)
        {
            AddParametro("@Logradouro", obj.Logradouro);
            AddParametro("@Numero", obj.Numero);
            AddParametro("@Bairro", obj.Bairro);
            AddParametro("@Cep", obj.Cep);
            AddParametro("@Uf", obj.Uf);
            AddParametro("@PontoReferencia", obj.PontoReferencia);
            AddParametro("@Cidade", obj.Cidade);
            var tabela = await ExecutarProcedureAsync("P_ENDERECO_INCLUIR");
            return int.TryParse(tabela.Rows[0]["Id"].ToString(), out int retorno) ? retorno : 0;
        }

        public async Task Deletar(Endereco obj)
        {
            AddParametro("@Id", obj.Id);
            await ExecutarProcedureAsync("P_ENDERECO_EXCLUIR_POR_ID");
        }

        public async Task Alterar(Endereco obj)
        {
            AddParametro("Logradouro", obj.Logradouro);
            AddParametro("Bairro", obj.Bairro);
            AddParametro("Numero", obj.Numero);
            AddParametro("Cep", obj.Cep);
            AddParametro("Uf", obj.Uf);
            AddParametro("Cidade", obj.Cidade);
            AddParametro("PontoReferencia", obj.PontoReferencia);
            AddParametro("ProprietarioId", obj.ProprietarioId);
            await ExecutarProcedureAsync("P_ENDERECO_ALTERAR");
        }
    }
}
