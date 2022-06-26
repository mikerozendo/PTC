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

        public Task Alterar(Imagem obj)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(Imagem obj)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> Inserir(Imagem obj)
        {
            AddParametro("CaminhoArquivo", obj.CaminhoInsertHelper);
            AddParametro("IdenficadorPasta", obj.EnumIdentificadorPastaDeArquivos);

            var tabela = await ExecutarProcedureAsync("P_IMAGEM_INSERIR");
            return int.TryParse(tabela.Rows[0]["Id"].ToString(), out int retorno) ? retorno : 0;
        }
    }
}
