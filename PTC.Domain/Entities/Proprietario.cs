using PTC.Domain.Enums;
using PTC.Domain.Extentitions;

namespace PTC.Domain.Entities
{
    public class Proprietario : Base
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string WhatsApp { get; set; }
        public Endereco Endereco { get; set; } = new();
        public EnumTipoPessoa EnumTipoPessoa { get { return DefiniTipoPessoa(); } }
        public EnumTipoProprietario EnumTipoProprietario { get; set; }

        public EnumTipoPessoa DefiniTipoPessoa()
        {
            string documentoFormato = Documento.DocumentoValidFormat();

            if (!string.IsNullOrEmpty(documentoFormato))
            {
                if (documentoFormato.Length == 11)
                    return EnumTipoPessoa.PessoaFisica;

                else if (documentoFormato.Length == 14)
                    return EnumTipoPessoa.PessoaJuridica;

                else return EnumTipoPessoa.NaoIdentificado;
            }
            
            return EnumTipoPessoa.NaoIdentificado;
        }
    }
}
