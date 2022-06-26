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
        public List<string> ImagensIds { get; set; } = new();

        public Imagem(EnumIdentificadorPastaDeArquivos identificador)
        {
            EnumIdentificadorPastaDeArquivos = identificador;
        }

        public Imagem(EnumIdentificadorPastaDeArquivos identificador, string caminhoInsert)
        {
            EnumIdentificadorPastaDeArquivos = identificador;
            CaminhoInsertHelper = caminhoInsert;
        }

        public Imagem(EnumIdentificadorPastaDeArquivos identificador, List<string> ids)
        {
            EnumIdentificadorPastaDeArquivos = identificador;
            ImagensIds = ids;
        }

        public Imagem(EnumIdentificadorPastaDeArquivos idenficador, int entidadeId, List<string> ids)
        {
            EnumIdentificadorPastaDeArquivos = idenficador;
            EntidadeDonaId = entidadeId;
            ImagensIds = ids;
        }
    }
}
