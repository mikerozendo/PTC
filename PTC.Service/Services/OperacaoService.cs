using System;
using System.Threading.Tasks;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Services;
using PTC.Domain.Interfaces.Repository;
using System.Collections.Generic;

namespace PTC.Application.Services
{
    public class OperacaoService : IOperacaoService
    {
        private readonly IVeiculosService _veiculosService;
        private readonly IOperacaoRepository _operacaoRepository;
        private readonly IImagemService _imagemService;

        public OperacaoService(IVeiculosService veiculosService, IOperacaoRepository operacaoRepository, IImagemService imagemService)
        {
            _veiculosService = veiculosService;
            _operacaoRepository = operacaoRepository;
            _imagemService = imagemService;
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
            List<string> ids = await InserirImagemDecorator(obj.Imagem);
            if (ids.Count > 0)
            {
                obj.Veiculo.Id = await _veiculosService.Inserir(obj.Veiculo);

                if (obj.Veiculo.Id > 0)
                {
                    if (!(obj.Proprietario is null))
                    {
                        try
                        {
                            return await _operacaoRepository.Inserir(obj) > 0 ? "sucesso" : "falha";
                        }
                        catch (Exception)
                        {
                            await _veiculosService.Deletar(obj.Veiculo);
                            return "Erro ocorrido ao cadastro nova operação";
                        }
                    }

                    else return "Informe um proprietario!";
                }
                else return "Erro ao cadastrar veículo!";
            }
            else return "Erro ao cadastrar imagens!";
        }

        public async Task<List<string>> InserirImagemDecorator(Imagem imagem)
        {
            if (!(imagem is null))
                return await _imagemService.Inserir(imagem);

            return new List<string>();
        }

        public async Task DeletarImagensDecorator(Imagem imagem)
        {
            await _imagemService.Deletar(imagem);
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
