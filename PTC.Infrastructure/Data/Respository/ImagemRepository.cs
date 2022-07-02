using Microsoft.Extensions.Configuration;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using PTC.Infrastructure.Data.Base;
using System;
using System.Threading.Tasks;

namespace PTC.Infrastructure.Data.Respository
{
    public class ImagemRepository : BaseRepository, IImagemRepository
    {
        public ImagemRepository(IConfiguration configuration) : base(configuration) { }

        public async Task Alterar(Imagem obj)
        {
            AddParametro("ImagemId", obj.IdImagemAtual);
            AddParametro("OperacaoId", obj.EntidadeDonaId);
            await ExecutarProcedureAsync("P_IMAGEM_ALTERAR_ID_ENTIDADE");
        }

        public async Task Deletar(Imagem obj)
        {
            AddParametro("ImagemId", obj.IdImagemAtual);
            await ExecutarProcedureAsync("P_CAMINHO_IMAGEM_DELETAR");
        }

        public async Task<int> Inserir(Imagem obj)
        {
            AddParametro("CaminhoArquivo", obj.CaminhoInsertHelper);
            AddParametro("IdenficadorPasta", obj.EnumIdentificadorPastaDeArquivos);

            var tabela = await ExecutarProcedureAsync("P_IMAGEM_INSERIR");
            return int.TryParse(tabela.Rows[0]["IdImagem"].ToString(), out int retorno) ? retorno : 0;
        }
    }
}
