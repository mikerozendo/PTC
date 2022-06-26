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

        public Imagem(EnumIdentificadorPastaDeArquivos identificador)
        {
            EnumIdentificadorPastaDeArquivos = identificador;
        }

        public Imagem(EnumIdentificadorPastaDeArquivos identificador, string caminhoInsert)
        {
            EnumIdentificadorPastaDeArquivos = identificador;
            CaminhoInsertHelper = caminhoInsert;
        }
    }
}
