using System;

namespace PTC.Domain.Entities
{
    public class Veiculo : Base
    {
        public string Renavam { get; set; }
        public Marca MarcaVeiculo { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public decimal Km { get; set; }
    }
}
