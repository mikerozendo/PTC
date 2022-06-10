using System;

namespace PTC.Application.Dtos
{
    public abstract class Base
    {
        public long Id { get; set; }
        public DateTime? Cadastro { get; set; }
        public DateTime? Exclusao { get; set; }
    }
}
