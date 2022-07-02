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
        public EnumTipoPessoa EnumTipoPessoa { get { return DefiniTipoPessoa(); } }
        public EnumTipoProprietario EnumTipoProprietario { get; set; }

        public EnumTipoPessoa DefiniTipoPessoa()
        {
            if (Documento.Length == 18)
                return EnumTipoPessoa.PessoaJuridica;

            else if (Documento.Length == 13)
                return EnumTipoPessoa.PessoaFisica;

            else return EnumTipoPessoa.NaoIdentificado; 
        }
    }
}
