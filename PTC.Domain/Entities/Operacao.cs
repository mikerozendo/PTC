using System;
using System.Collections.Generic;
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
        public decimal ValorCompra { get; set; }
        public decimal ValorTabela { get; set; }
        public decimal ValorRevenda { get; set; }
        public bool Vendido { get { return DataRevenda != null && ValorRevenda > 0; } }
        public Imagem Imagem { get; set; }
    }
}
