namespace PTC.Domain.Interfaces.Repository.CQRS
{
    public interface IQueryRepository<T> : IBaseQueryRepository<T> where T : class
    {
        T ObterPorId(int id);
        bool Existe(T obj);
    }
}
