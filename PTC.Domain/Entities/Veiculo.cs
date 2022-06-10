using System;

namespace PTC.Domain.Entities
{
    public class Veiculo : Base
    {
        public string Renavam { get; set; }
        public Marca MarcaVeiculo { get; set; }
        public string Modelo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime AnoModelo { get; set; }
        public decimal Km { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorTabela { get; set; }
        public decimal ValorRevenda { get; set; }
    }
}
