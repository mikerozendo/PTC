using System;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using PTC.Domain.Interfaces.Services;


namespace PTC.Application.Services
{
    public class VeiculosService : IVeiculosService
    {

        private readonly IVeiculosRepository _veiculosRepository;

        public VeiculosService(IVeiculosRepository veiculosRepository)
        {
            _veiculosRepository = veiculosRepository;
        }

        public void Alterar(Veiculo obj)
        {
            _veiculosRepository.Alterar(obj);
        }

        public dynamic Inserir(Veiculo obj)
        {
            return _veiculosRepository.Inserir(obj);
        }

        public void Deletar(Veiculo obj)
        {
            return;
        }

        public Veiculo ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Veiculo> ObterTodos()
        {
            return _veiculosRepository.ObterTodos();
        }

        public bool Existe(Veiculo obj)
        {
            throw new NotImplementedException();
        }
    }
}
