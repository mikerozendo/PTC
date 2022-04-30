using System.ComponentModel;

namespace PTC.Domain.Enums
{
    public enum EnumSituacao
    {
        [Description("Ativo")]
        Ativo = 0,

        [Description("Inativo")]
        Inativo = 1,

        [Description("Vendido")]
        Vendido = 3,

        [Description("Todos")]
        Todos = 4,
    }
}
