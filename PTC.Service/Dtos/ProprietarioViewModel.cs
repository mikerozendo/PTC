using Microsoft.AspNetCore.Http;

namespace PTC.Application.Dtos
{
    public class ProprietarioViewModel : Base
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string WhatsApp { get; set; }
        public int TipoPessoaId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string PontoReferencia { get; set; }
        public string Cidade { get; set; }
        public IFormFile Imagem { get; set; }
        public string CaminhoImagem { get; set; }
    }
}