using System.ComponentModel;

namespace PTC.Domain.Enums
{
    public enum EnumTipoProprietario
    {
        [Description("Vendedor")]
        Vendedor = 1,

        [Description("Comprador")]
        Comprador = 2,

        [Description("NaoIdentificado")]
        NaoIdentificado = 3,

        [Description("Nenhum")]
        Nenhum = 4
    }
}
