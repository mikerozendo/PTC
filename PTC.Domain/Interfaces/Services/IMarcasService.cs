using PTC.Domain.Entities;

namespace PTC.Domain.Interfaces.Services
{
    public interface IMarcasService : IBaseService<Marca>, IBaseGetService<Marca>
    {
        void Alterar(Marca obj);
    }
}
