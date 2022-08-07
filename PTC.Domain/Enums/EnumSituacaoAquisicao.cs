using System.ComponentModel.DataAnnotations;

namespace PTC.Domain.Enums
{
    public enum EnumSituacaoAquisicao
    {
        [Display(Name="Nenhum")]
        Nenhum = 0,

        [Display(Name = "Negociação de compra")]

        NegociacaoCompra = 1,

        [Display(Name = "Estoque")]
        Estoque = 2,

        [Display(Name = "Negociação de venda")]
        NegociacaoVenda = 3,

        [Display(Name = "Vendido")]
        Vendido = 4
    }
}
