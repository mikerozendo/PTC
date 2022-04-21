using PTC.Domain.Enums;
using PTC.Domain.Interfaces.Entities;
using System;

namespace PTC.Domain.Entities
{
    public class Proprietario : Base, IFormato
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string WhatsApp { get; set; }
        public Endereco Endereco { get; set; } = new();
        public EnumSituacao EnumSituacaoProprietario { get; set; }
        public EnumTipoPessoa EnumTipoPessoa { get; set; }

        public void FormatarValoresEscritaDb()
        {
            if (!string.IsNullOrEmpty(WhatsApp))
                WhatsApp = WhatsApp.Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty);
            if (!string.IsNullOrEmpty(Documento))
                Documento = Documento.Replace(".", "").Replace("-", string.Empty);
            if (Documento.Contains("/"))
                Documento = Documento.Replace("/", string.Empty);
        }

        public void FormatarValoresLeituraDb()
        {
            if (!string.IsNullOrEmpty(WhatsApp))
            {
                var array = WhatsApp.AsSpan();
                WhatsApp = $"({array.Slice(0,1).ToString()}) {array[2]} {array.Slice(3,6).ToString()}-{array.Slice(7, 10).ToString()}";
            }
            if (!string.IsNullOrEmpty(Documento))
            {
                var array = Documento.AsSpan();

                if (Documento.Length == 10)
                {
                    Documento =
                    $"{array.Slice(0, 2).ToString()}." +
                    $"{array.Slice(3, 5).ToString()}." +
                    $"{array.Slice(6, 8).ToString()}-" +
                    $"{array.Slice(9, 10).ToString()}";
                }
                else
                {
                    Documento =
                        $"{array.Slice(0, 1).ToString()}." +
                        $"{array.Slice(2, 4).ToString()}." +
                        $"{array.Slice(5, 7).ToString()}/" +
                        $"{array.Slice(8, 11).ToString()}-" +
                        $"{array.Slice(12, 13).ToString()}";
                }
            }
        }
    }
}
