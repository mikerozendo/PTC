using Microsoft.AspNetCore.Http;

namespace PTC.Domain.Entities.Base
{
    public abstract class BaseCadastroExtention : BaseCadastro
    {
        public IFormFile Imagem { get; set; }
        public string CaminhoImagem { get; set; }
    }
}
