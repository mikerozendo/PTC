using PTC.Domain.Interfaces.Entities;
using System;

namespace PTC.Domain.Entities
{
    public class Endereco : Base, IFormato
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string PontoReferencia { get; set; }

        public void FormatarEscritaDb()
        {
            if (!string.IsNullOrEmpty(Cep))
                Cep = Cep.Replace("-", string.Empty);
        }

        public void FormatarLeituraDb()
        {
            if (!string.IsNullOrEmpty(Cep))
            {
                var array = Cep.AsSpan();
                Cep = $"{array.Slice(0, 5).ToString()}-{array.Slice(5, 3).ToString()}";
            }
        }

        public override string ToString()
        {
            return
                $"{Logradouro}, {Numero}";
        }
    }
}
