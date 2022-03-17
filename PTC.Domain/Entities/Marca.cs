using PTC.Domain.Enums;

namespace PTC.Domain.Entities
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EnumSituacao EnumSituacao { get; set; }
    }
}
