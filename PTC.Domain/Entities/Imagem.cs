using PTC.Domain.Enums;
using System.Collections.Generic;

namespace PTC.Domain.Entities
{
    public class Imagem : Base
    {
        public EnumIdentificadorPastaDeArquivos EnumIdentificadorPastaDeArquivos { get; }
        public List<string> Caminhos { get; set; } = new();
        public int EntidadeDonaId { get; set; }
        public string CaminhoInsertHelper { get; set; }
        public List<int> ImagensIds { get; set; } = new();
        public int IdImagemAtual { get; set; }

        public Imagem() { }

        public Imagem(EnumIdentificadorPastaDeArquivos identificador)
        {
            EnumIdentificadorPastaDeArquivos = identificador;
        }

        public Imagem(EnumIdentificadorPastaDeArquivos identificador, string caminhoInsert)
        {
            EnumIdentificadorPastaDeArquivos = identificador;
            CaminhoInsertHelper = caminhoInsert;
        }

        public Imagem(EnumIdentificadorPastaDeArquivos identificador, List<int> ids)
        {
            EnumIdentificadorPastaDeArquivos = identificador;
            ImagensIds = ids;
        }

        public Imagem(EnumIdentificadorPastaDeArquivos idenficador, int entidadeId, List<int> ids)
        {
            EnumIdentificadorPastaDeArquivos = idenficador;
            EntidadeDonaId = entidadeId;
            ImagensIds = ids;
        }

        public Imagem(int idImagem, int idOperacao) 
        {
            IdImagemAtual = idImagem;
            EntidadeDonaId = idOperacao;
        }
    }
}
