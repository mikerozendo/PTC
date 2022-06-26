using System;
using System.Threading.Tasks;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Services;
using PTC.Domain.Interfaces.Repository;

namespace PTC.Application.Services
{
    public class OperacaoService : IOperacaoService
    {
        private readonly IVeiculosService _veiculosService;
        private readonly IOperacaoRepository _operacaoRepository;

        public OperacaoService(IVeiculosService veiculosService, IOperacaoRepository operacaoRepository)
        {
            _veiculosService = veiculosService;
            _operacaoRepository = operacaoRepository;
        }

        public async Task Deletar(Operacao obj)
        {
            await _veiculosService.Deletar(obj.Veiculo);
            await _operacaoRepository.Deletar(obj);
        }

        public async Task<dynamic> Inserir(Operacao obj)
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

        public async Task<Operacao> ObterPorId(int id)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
