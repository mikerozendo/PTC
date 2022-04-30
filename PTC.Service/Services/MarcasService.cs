using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using PTC.Domain.Interfaces.Services;

namespace PTC.Application.Services
{
    public class MarcasService : IMarcasService
    {
        private readonly IMarcasRepository _marcasRepository;

        public MarcasService(IMarcasRepository marcasRepository)
        {
            _marcasRepository = marcasRepository;
        }

        public void Deletar(Marca obj)
        {
            _marcasRepository.Alterar(obj);
        }

        public IEnumerable<Marca> Inserir(Marca obj)
        {
            return _marcasRepository.Inserir(obj);
        }

        public IEnumerable<Marca> ObterTodos()
        {
            // return _marcasRepository.ObterTodos();
            return new List<Marca>();
        }
    }
}
