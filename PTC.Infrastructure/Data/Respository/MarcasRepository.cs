using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using PTC.Infrastructure.Data.Base;

namespace PTC.Infrastructure.Data.Respository
{
    public class MarcasRepository : BaseRepository, IMarcasRepository
    {
        public void Alterar(Marca obj)
        {
            AddParametro("Nome", obj.Nome);
            AddParametro("Id", obj.Id);
            AddParametro("Status", obj.EnumSituacao);
            ExecutarProcedure("P_MARCA_ALTERAR");
        }

        public void Deletar(Marca obj)
        {
            Alterar(obj);
        }

        public dynamic Inserir(Marca obj)
        {
            AddParametro("Nome", obj.Nome);
            ExecutarProcedure("P_MARCA_INSERIR");
            return string.Empty;
        }
    }
}
