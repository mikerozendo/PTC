using System;
using PTC.Domain.Enums;
using PTC.Domain.Extentitions;

namespace PTC.Domain.Entities
{
    public class Documento
    {
        public EnumTipoDocumento EnumTipoDocumento { get; private set; } = EnumTipoDocumento.Nenhum;
        public string Numero { get; private set; }
        public string NumeroFormatado { get; private set; }

        public Documento(string numero)
        {
            Numero = numero;
            NumeroFormatado = FormatarDocumento();
            DefiniTipoDocumento();
        }

        private string FormatarDocumento()
        {
            string documentoFormatado = Numero.DocumentoValidFormat();

            if (!string.IsNullOrEmpty(documentoFormatado)) return documentoFormatado;

            else throw new ArgumentNullException("Número de documento não Fornecido");
        }

        private void DefiniTipoDocumento()
        {
            if (NumeroFormatado.Length == 11)
                EnumTipoDocumento = EnumTipoDocumento.CPF;

            else if (NumeroFormatado.Length == 14)
                EnumTipoDocumento = EnumTipoDocumento.CNPJ;                
        }
    }
}
