namespace PTC.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        dynamic Inserir(T obj);
        void Deletar(T obj);
        T ObterPorId(int id);
    }
}
