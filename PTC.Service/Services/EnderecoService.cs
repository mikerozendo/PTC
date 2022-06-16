using System;
using System.Threading.Tasks;
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

        public async Task Alterar(Endereco obj)
        {
           await _enderecoRepository.Alterar(obj);
        }

        public async Task Deletar(Endereco obj)
        {
            await _enderecoRepository.Deletar(obj);
        }

        public async Task<Endereco> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> Inserir(Endereco obj)
        {
            return await _enderecoRepository.Inserir(obj);
        }
    }
}
