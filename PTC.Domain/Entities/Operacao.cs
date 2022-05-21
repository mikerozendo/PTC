using System;
using PTC.Domain.Entities.Base;
using PTC.Domain.Enums;

namespace PTC.Domain.Entities
{
    public class Operacao : BaseCadastro
    {
        public Proprietario Proprietario { get; set; }
        public Proprietario Comprador { get; set; }
        public Veiculo Veiculo { get; set; }
        public EnumSituacaoAquisicao EnumSituacaoAquisicao { get; set; }
        public EnumFormaPagamento EnumTipoPagamentoAquisicao { get; set; }
        public EnumFormaPagamento EnumTipoPagamentoRevenda { get; set; }
        public DateTime? DataAquisicao { get; set; } = null;
        public DateTime? DataRevenda { get; set; } = null;
    }
}
