﻿using System;
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
        public decimal Km { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorRevenda { get { return ValorCompra + (ValorCompra * 20 / 100); } }
        public EnumSituacao EnumSituacao { get; set; }
        public IFormFile Imagem { get; set; }
        public string CaminhoImagem { get; set; }
    }
}
