using System;
using Microsoft.AspNetCore.Http;
using PTC.Domain.Enums;
using PTC.Domain.Interfaces.Entities;

namespace PTC.Domain.Entities
{
    public class Proprietario : Base, IFormato
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string WhatsApp { get; set; }
        public Endereco Endereco { get; set; } = new();
        public IFormFile Imagem { get; set; }
        public string CaminhoImagem { get; set; }
        public EnumSituacao EnumSituacaoProprietario { get; set; }
        public EnumTipoPessoa EnumTipoPessoa { get; set; }

        public void FormatarEscritaDb()
        {
            if (!string.IsNullOrEmpty(WhatsApp))
                WhatsApp = WhatsApp.Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty);

            if (!string.IsNullOrEmpty(Documento))
            {
                Documento = Documento.Replace(".", "").Replace("-", string.Empty);
                if (Documento.Contains("/"))
                    Documento = Documento.Replace("/", string.Empty);
            }
        }

        public void FormatarLeituraDb()
        {
            if (!string.IsNullOrEmpty(WhatsApp))
            {
                var array = WhatsApp.AsSpan();
                WhatsApp = $"({array.Slice(0, 2).ToString()}) {array[2]} {array.Slice(3, 4).ToString()}-{array.Slice(7, 4).ToString()}";
            }
            if (!string.IsNullOrEmpty(Documento))
            {
                var array = Documento.AsSpan();

                if (Documento.Length == 11)
                {
                    Documento =
                    $"{array.Slice(0, 3).ToString()}." +
                    $"{array.Slice(3, 3).ToString()}." +
                    $"{array.Slice(6, 3).ToString()}-" +
                    $"{array.Slice(9, 2).ToString()}";
                }
                else
                {
                    Documento =
                        $"{array.Slice(0, 2).ToString()}." +
                        $"{array.Slice(2, 3).ToString()}." +
                        $"{array.Slice(5, 3).ToString()}/" +
                        $"{array.Slice(8, 4).ToString()}-" +
                        $"{array.Slice(12, 2).ToString()}";
                }
            }
        }
    }
}
