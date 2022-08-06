using System.ComponentModel;

namespace PTC.Domain.Enums
{
    public enum EnumSituacaoAquisicao
    {
        [Description("Nenhum")]
        Nenhum = 0,

        [Description("Negociação de compra")]
        NegociacaoCompra = 1,

        [Description("Estoque")]
        Estoque = 2,

        [Description("Negociação de venda")]
        NegociacaoVenda = 3,

        [Description("Vendido")]
        Vendido = 4
    }
}
