using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository.CQRS;

namespace PTC.Domain.Interfaces.Repository
{
    public interface IImagemRepository : ICommandRepository<Imagem> { }
}
