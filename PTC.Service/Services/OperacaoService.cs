using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PTC.Domain.Enums;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Services;
using PTC.Domain.Interfaces.Repository;

namespace PTC.Application.Services
{
    public class OperacaoService : Base, IOperacaoService
    {
        private readonly IVeiculosService _veiculosService;
        private readonly IOperacaoRepository _operacaoRepository;
        private readonly IImagemService _imagemService;

        public OperacaoService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _veiculosService = (IVeiculosService)_serviceProvider.GetService(typeof(IVeiculosService));
            _operacaoRepository = (IOperacaoRepository)_serviceProvider.GetService(typeof(IOperacaoRepository));
            _imagemService = (IImagemService)_serviceProvider.GetService(typeof(IImagemService));
        }

        public async Task Deletar(Operacao obj)
        {
            await _veiculosService.Deletar(obj.Veiculo);
            await _operacaoRepository.Deletar(obj);
        }

        public Task<bool> Existe(Operacao obj)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> Inserir(Operacao obj)
        {
            List<int> idsImagens = await _imagemService.Inserir(obj.Imagem);
            if (idsImagens.Count > 0)
            {
                obj.Veiculo.Id = await _veiculosService.Inserir(obj.Veiculo);

                if (obj.Veiculo.Id > 0)
                {
                    if (!(obj.Proprietario is null))
                    {
                        try
                        {
                            int operacaoId = await _operacaoRepository.Inserir(obj);
                            if (operacaoId > 0)
                            {
                                await _imagemService.Alterar(new(EnumIdentificadorPastaDeArquivos.Veiculos, operacaoId, idsImagens));
                                return "sucesso";
                            }
                            else
                            {
                                await RollBackBuilder(true, true, new(EnumIdentificadorPastaDeArquivos.Veiculos, idsImagens), obj.Veiculo);
                                return "falha";
                            }
                        }
                        catch (Exception)
                        {
                            await RollBackBuilder(true, true, new(EnumIdentificadorPastaDeArquivos.Veiculos, idsImagens), obj.Veiculo);
                            return "Erro ocorrido ao cadastro nova operação";
                        }
                    }
                    else
                    {
                        await RollBackBuilder(true, true, new(EnumIdentificadorPastaDeArquivos.Veiculos, idsImagens), obj.Veiculo);
                        return "Informe um proprietario!";
                    }
                }
                else
                {
                    await RollBackBuilder(true, false, new(EnumIdentificadorPastaDeArquivos.Veiculos, idsImagens), null);
                    return "Erro ao cadastrar veículo!";
                }
            }
            else return "Erro ao cadastrar imagens!";
        }

        public async Task RollBackBuilder(bool imageService, bool veiculoService, Imagem imageObj = null, Veiculo veiculoObj = null)
        {
            if (imageService)
                await _imagemService.Deletar(imageObj);

            if (veiculoService)
                await _veiculosService.Deletar(veiculoObj);
        }

        public async Task<Operacao> ObterPorId(int id)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Operacao>> ObterTodos()
        {
            return _operacaoRepository.ObterTodos();
        }
    }
}
