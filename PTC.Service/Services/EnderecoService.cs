using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using PTC.Domain.Interfaces.Services;

namespace PTC.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public int ExcluirPorId(int id)
        {
            return _enderecoRepository.ExcluirPorId(id);
        }

        public int Incluir(Endereco obj)
        {
            return _enderecoRepository.Incluir(obj);
        }

        public Endereco ObterPorIdProprietario(int id)
        {
            return _enderecoRepository.ObterPorIdProprietario(id);
        }
    }
}
