using System.ComponentModel;

namespace PTC.Domain.Enums
{
    public enum EnumTipoPessoa
    {
        [Description("Pessoa Juridica")]
        PessoaJuridica = 1,

        [Description("Pessoa Fisica")]
        PessoaFisica = 2,

        [Description("Não informado")]
        NaoIdentificado = 3
    }
}
