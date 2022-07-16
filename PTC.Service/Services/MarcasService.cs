using System.Threading.Tasks;
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

        public async Task Alterar(Marca obj)
        {
            await _marcasRepository.Alterar(obj);
        }

        public async Task Deletar(Marca obj)
        {
            await _marcasRepository.Deletar(obj);
        }

        public async Task<bool> Existe(Marca obj)
        {
            return await _marcasRepository.Existe(obj);
        }

        public async Task<string> Inserir(Marca obj)
        {
            if (!await Existe(obj))
            {
                await _marcasRepository.Inserir(obj);
                return "Sucesso";
            }

            else return "Marca já existente!";
        }

        public async Task<Marca> ObterPorId(int id)
        {
            return await _marcasRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Marca>> ObterTodos()
        {
            return await _marcasRepository.ObterTodos();
        }
    }
}
