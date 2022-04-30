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

        public void Alterar(Marca obj)
        {
            _marcasRepository.Alterar(obj);
        }

        public void Deletar(Marca obj)
        {
            _marcasRepository.Deletar(obj);
        }

        public bool Existe(Marca obj)
        {
            return _marcasRepository.Existe(obj);
        }

        public string Inserir(Marca obj)
        {
            if (!Existe(obj))
                return _marcasRepository.Inserir(obj);

            else return "Marca já existente!";
        }

        public Marca ObterPorId(int id)
        {
            return _marcasRepository.ObterPorId(id);
        }

        public IEnumerable<Marca> ObterTodos()
        {
            return _marcasRepository.ObterTodos();
        }
    }
}
