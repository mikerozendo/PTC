using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC.Domain.Interfaces.Repository
{
    public interface IVeiculosRepository : ICommandRepository<Veiculo>
    {
    }
}
