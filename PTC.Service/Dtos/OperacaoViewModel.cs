using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace PTC.Application.Dtos
{
    public class OperacaoViewModel : Base
    {
        public int ProprietarioId { get; set; }
        public int CompradorId { get; set; }
        public string RenavamVeiculo { get; set; }
        public string ProprietarioNome { get; set; }
        public string CompradorNome { get; set; }
        public string NomeVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public string ValorCompraMoedaFormatada { get; set; }
        public string ValorRevendaMoedaFormatada { get; set; }
        public int MarcaVeiculoId { get; set; }
        public decimal Km { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorTabela { get; set; }
        public decimal ValorRevenda { get; set; }
        public DateTime DataFabricacaoVeiculo { get; set; }
        public DateTime AnoModeloVeiculo { get; set; }
        public DateTime? DataRevenda { get; set; } = null;
        public int SituacaoAquisicaoId { get; set; }
        public int TipoPagamentoAquisicaoId { get; set; }
        public int TipoPagamentoRevendaId { get; set; }
        public int VeiculoId { get; set; }
        public List<ImagemViewModel> Imagens { get; set; } = new();
        public List<IFormFile> ArquivosImagens { get; set; } = new();
    }
}
