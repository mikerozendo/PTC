using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using PTC.Domain.Interfaces.Services;

namespace PTC.Application.Services
{
    public class VeiculosService : BaseService, IVeiculosService
    {
        private readonly IVeiculosRepository _veiculosRepository;

        public VeiculosService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _veiculosRepository = (IVeiculosRepository) serviceProvider.GetService(typeof(IVeiculosRepository));
        }

        public async Task Alterar(Veiculo obj)
        {
           await _veiculosRepository.Alterar(obj);
        }

        public async Task<dynamic> Inserir(Veiculo obj)
        {
            return await _veiculosRepository.Inserir(obj);
        }

        public async Task Deletar(Veiculo obj)
        {
            await _veiculosRepository.Deletar(obj);
        }

        public async Task<Veiculo> ObterPorId(int id)
        {
            await Task.CompletedTask; return new();
        }

        public async Task<IEnumerable<Veiculo>> ObterTodos()
        {
            return await _veiculosRepository.ObterTodos();
        }

        public async Task<bool> Existe(Veiculo obj)
        {
            await Task.CompletedTask; return true;
        }
    }
}
