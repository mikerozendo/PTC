using System;
using Microsoft.AspNetCore.Http;

namespace PTC.Application.Dtos
{
    public abstract class Base
    {
        public int Id { get; set; }
        public DateTime? Cadastro { get; set; }
        public DateTime? Exclusao { get; set; }
        public string CaminhoImagem { get; set; }
        public IFormFile Imagem { get; set; }
    }
}
