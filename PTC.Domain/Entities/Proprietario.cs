using PTC.Domain.Enums;
using System.Collections.Generic;

namespace PTC.Domain.Entities
{
    public class Proprietario : Base
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string WhatsApp { get; set; }
        public Documento Documento { get; set; }
        public Endereco Endereco { get; set; } = new();
        public EnumTipoPessoa EnumTipoPessoa { get; private set; } = EnumTipoPessoa.NaoIdentificado;
        public EnumTipoProprietario EnumTipoProprietario { get; set; }//remover??
        public List<Operacao> Operacoes { get; set; } = new();

        public Proprietario(string numeroDocumento)
        {
            Documento = new Documento(numeroDocumento);
            DefiniTipoPessoa();
        }
        public Proprietario(int id)
        {
            Id = id;
        }
        public Proprietario() { }


        private void DefiniTipoPessoa()
        {
            if (Documento.EnumTipoDocumento == EnumTipoDocumento.CPF)
                EnumTipoPessoa = EnumTipoPessoa.PessoaFisica;

            else if (Documento.EnumTipoDocumento == EnumTipoDocumento.CNPJ)
                EnumTipoPessoa = EnumTipoPessoa.PessoaJuridica;
        }
    }
}
