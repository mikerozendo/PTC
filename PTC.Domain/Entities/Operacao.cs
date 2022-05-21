using PTC.Domain.Enums;

namespace PTC.Domain.Entities
{
    public class Operacao
    {
        public Proprietario Proprietario { get; set; }
        public Proprietario Comprador { get; set; }
        public Veiculo Veiculo { get; set; }
        public EnumSituacaoAquisicao EnumSituacaoAquisicao { get; set; }
        public EnumTipoPagamento EnumTipoPagamentoAquisicao { get; set; }
        public EnumTipoPagamento EnumTipoPagamentoRevenda { get; set; }
    }
}
