using System;
using Microsoft.AspNetCore.Http;

namespace PTC.Domain.Entities.Base
{
    public abstract class BaseCadastro
    {
        public int Id { get; set; }
        public DateTime? Cadastro { get; set; } = null;
        public DateTime? Exclusao { get; set; } = null;
    }
}
