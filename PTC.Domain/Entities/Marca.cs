using PTC.Domain.Entities.Base;
using PTC.Domain.Enums;

namespace PTC.Domain.Entities
{
    public class Marca : BaseCadastro
    {
        public string Nome { get; set; }
        public string UrlImagem { get; set; }
    }
}
