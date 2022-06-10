using System;

namespace PTC.Application.Dtos
{
    public class OperacaoViewModel : Base
    {
        public int ProprietarioId { get; set; }
        public int CompradorId { get; set; }
        public string RenavamVeiculo { get; set; }
        public int MarcaVeiculoId { get; set; }
        public string NomeVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public DateTime DataFabricacaoVeiculo { get; set; }
        public DateTime AnoModeloVeiculo { get; set; }
        public decimal Km { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorTabela { get; set; }
        public decimal ValorRevenda { get; set; }
        public int SituacaoAquisicaoId { get; set; }
        public int TipoPagamentoAquisicaoId { get; set; }
        public int TipoPagamentoRevendaId { get; set; }
        public DateTime? DataRevenda { get; set; } = null;
        public int VeiculoId { get; set; }
    }
}
