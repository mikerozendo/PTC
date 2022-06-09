using System;
using Microsoft.AspNetCore.Http;

namespace PTC.Application.Dtos
{
    public class OperacaoViewModel
    {
        public int ProprietarioId { get; set; }
        public int CompradorId { get; set; }
        public string RenavamVeiculo { get; set; }
        public int MarcaVeiculoId { get; set; }
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
        public DateTime? DataAquisicao { get; set; } = null;
        public DateTime? DataRevenda { get; set; } = null;
        public DateTime? CadastroVeiculo { get; set; } = null;
        public DateTime? ExclusaoVeiculo { get; set; } = null;
        public IFormFile Imagem { get; set; }
        public string CaminhoImagem { get; set; }
        public int VeiculoId { get; set; }
    }
}
