﻿using System.Data;

namespace PTC.Infrastructure.Data
{
    public abstract class Parametro
    {
        public string Nome { get; set; }
        public SqlDbType Tipo { get; set; }
        public object Valor { get; set; }
    }
}
