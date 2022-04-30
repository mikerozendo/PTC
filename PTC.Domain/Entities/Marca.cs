using PTC.Domain.Enums;

namespace PTC.Domain.Entities
{
    public class Marca : Base
    {
        public string Nome { get; set; }
        public EnumSituacao EnumSituacao { get; set; }
        public string UrlImagem { get; set; }
    }
}
