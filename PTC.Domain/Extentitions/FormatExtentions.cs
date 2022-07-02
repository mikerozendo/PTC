using System;

namespace PTC.Domain.Extentitions
{
    public static class FormatExtentions
    {
        public static string DocumentoValidFormat(this string documento)
        {
            string documentoFormatado = documento;

            if (documentoFormatado.Contains("."))
                documentoFormatado = documentoFormatado.Replace(".", String.Empty);

            if (documentoFormatado.Contains("-"))
                documentoFormatado = documentoFormatado.Replace("-", String.Empty);

            if (documentoFormatado.Contains("/"))
                documentoFormatado = documentoFormatado.Replace("/", String.Empty);

            return documentoFormatado;
        }
    }
}
