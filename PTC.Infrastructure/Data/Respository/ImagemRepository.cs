using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PTC.Domain.Entities;
using PTC.Infrastructure.Data.Base;
using PTC.Domain.Interfaces.Repository;

namespace PTC.Infrastructure.Data.Respository
{
    public class ImagemRepository : BaseRepository, IImagemRepository
    {
        public ImagemRepository(IConfiguration configuration) : base(configuration) { }

        public async Task Alterar(Imagem obj)
        {
            AddParametro("ImagemId", obj.IdImagemAtual);
            AddParametro("OperacaoId", obj.EntidadeDonaId);
            await ExecutarProcedureAsync("P_IMAGEM_ALTERAR_ENTIDADE_DONA");
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

        public async Task<int> InserirImagemProprietario(Imagem obj)
        {
            //FALTA CRIAR PROCEDURE
            AddParametro("CaminhoArquivo", obj.CaminhoInsertHelper);
            AddParametro("IdenficadorPasta", obj.EnumIdentificadorPastaDeArquivos);

            var tabela = await ExecutarProcedureAsync("P_IMAGEM_PROPRIETARIO_INSERIR");

            return int.TryParse(tabela.Rows[0]["IdImagem"].ToString(), out int retorno) ? retorno : 0;
        }

        public async Task<List<string>> ObterImagensVeiculosPorIdOperacao(int idOperacao)
        {
            List<string> caminhosArquivos = new();

            AddParametro("OperacaoId", idOperacao);
            var tabela = await ExecutarProcedureAsync("P_IMAGENS_CAMINHOS_ARQUIVOS_OBTER_POR_ID_OPERACAO");

            foreach (DataRow sdr in tabela.Rows)
            {
                caminhosArquivos.Add(Path.Combine(sdr["caminhoArquivo"].ToString()));
            }

            return caminhosArquivos;
        }
    }
}
