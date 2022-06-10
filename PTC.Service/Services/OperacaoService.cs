using System;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using PTC.Domain.Interfaces.Services;

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

        public void Deletar(Operacao obj)
        {
            _veiculosService.Deletar(obj.Veiculo);
            _operacaoRepository.Deletar(obj);
        }

        public dynamic Inserir(Operacao obj)
        {
            obj.Veiculo.Id = _veiculosService.Inserir(obj.Veiculo);

            if (obj.Veiculo.Id != 0)
            {
                if (!(obj.Proprietario is null))
                {
                    try
                    {
                        return _operacaoRepository.Inserir(obj) > 0 ? "sucesso" : "falha";
                    }
                    catch (Exception)
                    {
                        _veiculosService.Deletar(obj.Veiculo);
                        return "Erro ocorrido ao cadastro nova operação";
                    }
                }

                else return "Informe um proprietario!";
            } 
            else return "Erro ao cadastrar veículo!";
        }

        public Operacao ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
