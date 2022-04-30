using System;

namespace PTC.Domain.Entities
{
    public abstract class Base
    {
        public int Id { get; set; }
        public DateTime? Cadastro { get; set; } = null;
        public DateTime? Exclusao { get; set; } = null;
    }
}
