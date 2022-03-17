using PTC.Domain.Enums;
using System;

namespace PTC.Domain.Entities
{
    public class Veiculo
    {
        public int Id { get; set; }
        public Proprietario Proprietario { get; set; }
        public string Renavam { get; set; }
        public Marca MarcaVeiculo { get; set; }
        public string Modelo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime AnoModelo { get; set; }
        public string Km { get; set; }
        public decimal Valor { get; set; }
        public EnumSituacao EnumSituacao { get; set; }
    }
}
