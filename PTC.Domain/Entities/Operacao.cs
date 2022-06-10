using System;
using PTC.Domain.Enums;

namespace PTC.Domain.Entities
{
    public class Operacao : Base
    {
        public Proprietario Proprietario { get; set; }
        public Proprietario Comprador { get; set; }
        public Veiculo Veiculo { get; set; }
        public EnumSituacaoAquisicao EnumSituacaoAquisicao { get; set; }
        public EnumFormaPagamento EnumTipoPagamentoAquisicao { get; set; }
        public EnumFormaPagamento EnumTipoPagamentoRevenda { get; set; }
        public DateTime? DataRevenda { get; set; } = null;
    }
}
