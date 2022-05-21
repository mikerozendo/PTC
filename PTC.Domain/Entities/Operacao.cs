using System.Collections.Generic;
using PTC.Domain.Enums;

namespace PTC.Domain.Entities
{
    public class Operacao
    {
        public Proprietario Proprietario { get; set; }
        public Proprietario Comprador { get; set; }
        public Veiculo Veiculo { get; set; }
        public EnumSituacaoAquisicao EnumSituacaoAquisicao { get; set; }
    }
}
