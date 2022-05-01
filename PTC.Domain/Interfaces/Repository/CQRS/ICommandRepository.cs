namespace PTC.Domain.Interfaces.Repository.CQRS
{
    public interface ICommandRepository<T> where T : class
    {
        dynamic Inserir(T obj);
        void Deletar(T obj);
        void Alterar(T obj);
    }
}
