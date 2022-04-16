using PTC.Domain.Enums;

namespace PTC.Domain.Entities
{
    public class Proprietario : Base
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string WhatsApp { get; set; }
        public Endereco Endereco { get; set; } = new();
        public EnumSituacao EnumSituacaoProprietario { get; set; }
        public EnumTipoPessoa EnumTipoPessoa { get; set; }

        public void FormatarValoresEnvioDb()
        {
            WhatsApp = WhatsApp.Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty);
            Documento = Documento.Replace(".", "").Replace("-", string.Empty);
            if (Documento.Contains("/"))
                Documento = Documento.Replace("/", string.Empty);
        }

        public void FormatarValoresRetornoDb()
        {
            var array = WhatsApp.ToCharArray();

            WhatsApp = $"({array[0]}{array[1]}) {array[2]} {array[3]}{array[4]}{array[5]}{array[6]}-{array[7]}{array[8]}{array[9]}{array[10]}";

            array = Documento.ToCharArray();

            if (Documento.Length == 10)
                Documento = $"{array[0]}{array[1]}{array[2]}.{array[3]}{array[4]}{array[5]}.{array[6]}{array[6]}{array[8]}-{array[9]}{array[10]}";
            else
                Documento = $"{array[0]}{array[1]}.{array[2]}{array[3]}{array[4]}.{array[5]}{array[6]}{array[7]}/{array[8]}{array[9]}{array[10]}{array[11]}-{array[12]}{array[13]}";
        }
    }
}
