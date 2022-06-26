﻿using PTC.Domain.Entities;
using PTC.Domain.Enums;
using PTC.Domain.Interfaces.Repository;
using PTC.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTC.Application.Services
{
    public class ImagemService : IImagemService
    {
        private readonly IImagemRepository _imagemRepository;
        public ImagemService(IImagemRepository imagemRepository)
        {
            _imagemRepository = imagemRepository;
        }

        public Task Deletar(Imagem obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task<dynamic> Inserir(Imagem obj)
        {
            List<int> ids = new();

            foreach (string caminho in obj.Caminhos)
            {
                ids.Add(await _imagemRepository.Inserir(new(EnumIdentificadorPastaDeArquivos.Veiculos, caminho)));
            }

            return ids;
        }

        public Task<Imagem> ObterPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
