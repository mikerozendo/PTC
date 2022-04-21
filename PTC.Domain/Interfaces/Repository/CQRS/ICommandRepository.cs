namespace PTC.Domain.Interfaces.Repository.CQRS
{
    public interface ICommandRepository<T>
    {
        void Inserir(T obj);
        void Deletar(T obj);
        void Alterar(T obj);
    }
}
