using System.ComponentModel;

namespace PTC.Domain.Enums
{
    public enum EnumTipoPessoa
    {
        [Description("Pessoa Juridica")]
        PessoaJuridica = 0,

        [Description("Pessoa Fisica")]
        PessoaFisica = 1,

        [Description("Não informado")]
        NaoIdentificado = 2
    }
}
