using System.Threading.Tasks;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Domain.Enums;
using PTC.Domain.Interfaces.Repository;
using PTC.Domain.Interfaces.Services;
using System;
using System.Linq;

namespace PTC.Application.Services
{
    public class ImagemService : BaseService, IImagemService
    {
        private readonly IImagemRepository _imagemRepository;

        public ImagemService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _imagemRepository = (IImagemRepository)serviceProvider.GetService(typeof(IImagemRepository));
        }

        public async Task Alterar(Imagem obj)
        {
            foreach (int item in obj.ImagensIds)
            {
                await _imagemRepository.Alterar(new(item, obj.EntidadeDonaId));
            }
        }

        public async Task Deletar(Imagem obj)
        {
            foreach (int item in obj.ImagensIds)
            {
                await _imagemRepository.Deletar(new(item, obj.EntidadeDonaId));
            }
        }

        public async Task<string> Inserir(Imagem obj)
        {
            List<int> ids = new();

            foreach (string caminho in obj.Caminhos)
            {
                ids.Add(await _imagemRepository.Inserir(new(EnumIdentificadorPastaDeArquivos.Veiculos, caminho)));
            }

            if (ids.Count > 0)
                return String.Concat(ids.Select(x => String.Concat(x.ToString(), ",")))[..^1];

            return String.Empty;
        }

        public Task<Imagem> ObterPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
