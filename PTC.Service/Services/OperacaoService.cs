﻿using System;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using PTC.Domain.Interfaces.Services;

namespace PTC.Application.Services
{
    public class OperacaoService : IOperacaoService
    {
        private readonly IVeiculosService _veiculosService;
        private readonly IOperacaoRepository _operacaoRepository;

        public OperacaoService(IVeiculosService veiculosService)
        {
            _veiculosService = veiculosService;
        }

        public void Deletar(Operacao obj)
        {
            throw new NotImplementedException();
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
