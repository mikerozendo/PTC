namespace PTC.Domain.Entities
{
    public class Endereco : Base
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string PontoReferencia { get; set; }

        public void FormataCep()
        {
            Cep.Replace("-", string.Empty);
        }
    }
}
