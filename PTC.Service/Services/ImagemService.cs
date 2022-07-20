using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PTC.Domain.Enums;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Services;
using PTC.Domain.Interfaces.Repository;

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
            if (obj is null) throw new ApplicationException("Cadastre as imagens do veículo!");

            List<int> ids = new();

            foreach (string caminho in obj.Caminhos)
            {
                ids.Add(await _imagemRepository.Inserir(new(obj.EnumIdentificadorPastaDeArquivos, caminho)));
            }

            if (ids.Count > 0)
                return String.Concat(ids.Select(x => String.Concat(x.ToString(), ",")))[..^1];

            return String.Empty;
        }

        public async Task<int> InserirImagemProprietario(Imagem obj)
        {
            return await _imagemRepository.InserirImagemProprietario(obj);
        }

        public async Task<List<string>> ObterImagensVeiculosPorIdOperacao(int idOperacao, bool download)
        {
            var response = await _imagemRepository
                .ObterImagensVeiculosPorIdOperacao(idOperacao);

            //Coletando caminhos de imagem formatados p/ ou exibição via geração de HTML dinâmico por request, ou geração de arquivo PFD
            //Formatacoes de texto diferente para as duas situações

            if (!download)
            {
                return
                    response
                    .Select(x => x.ToString()[x.IndexOf("wwwroot")..].Replace("wwwroot", String.Empty).Replace(@"\", "/"))
                    .ToList();
            }

            return response.Select(x => Path.Combine(x)).ToList();
        }

        public Task<Imagem> ObterPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
