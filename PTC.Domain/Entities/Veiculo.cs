using System;
using Microsoft.AspNetCore.Http;
using PTC.Domain.Enums;

namespace PTC.Domain.Entities
{
    public class Veiculo : Base
    {
        public Proprietario Proprietario { get; set; }
        public string Renavam { get; set; }
        public Marca MarcaVeiculo { get; set; }
        public string Modelo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime AnoModelo { get; set; }
        public string Km { get; set; }
        public decimal Valor { get; set; }
        public EnumSituacao EnumSituacao { get; set; }
        public IFormFile Imagem { get; set; }
        public string CaminhoImagem { get; set; }
    }
}
