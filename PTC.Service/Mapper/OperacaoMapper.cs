using PTC.Domain.Enums;
using PTC.Domain.Entities;
using PTC.Application.Dtos;
using System;

namespace PTC.Application.Mapper
{
    public static class OperacaoMapper
    {
        public static Operacao ToDomain(OperacaoViewModel viewModel)
        {
            return new Operacao
            {
                Veiculo = new Veiculo
                {
                    Nome = viewModel.NomeVeiculo,
                    Cadastro = viewModel.Cadastro,
                    CaminhoImagem = viewModel.CaminhoImagem,
                    DataFabricacao = viewModel.DataFabricacaoVeiculo,
                    Exclusao = viewModel.DataFabricacaoVeiculo,
                    Id = viewModel.VeiculoId,
                    Km = viewModel.Km,
                    Modelo = viewModel.ModeloVeiculo,
                    Renavam = viewModel.RenavamVeiculo,
                    MarcaVeiculo = new Marca
                    {
                        Id = viewModel.MarcaVeiculoId
                    }
                },
                Comprador = new Proprietario
                {
                    Id = viewModel.ProprietarioId,
                },
                Proprietario = new Proprietario
                {
                    Id = viewModel.CompradorId
                },
                EnumSituacaoAquisicao = (EnumSituacaoAquisicao)viewModel.SituacaoAquisicaoId,
                EnumTipoPagamentoAquisicao = (EnumFormaPagamento)viewModel.TipoPagamentoAquisicaoId,
                EnumTipoPagamentoRevenda = (EnumFormaPagamento)viewModel.TipoPagamentoRevendaId,
                DataRevenda = viewModel.DataRevenda,
                Cadastro = viewModel.Cadastro,
                Exclusao = viewModel.Exclusao,
                ValorCompra = viewModel.ValorCompra,
                ValorRevenda = viewModel.ValorRevenda,
                ValorTabela = viewModel.ValorTabela
            };
        }

        public static OperacaoViewModel ToViewModel(Operacao domain)
        {
            return new OperacaoViewModel
            {
                Cadastro = domain.Cadastro,
                CaminhoImagem = domain.Veiculo.CaminhoImagem,
                DataFabricacaoVeiculo = domain.Veiculo.DataFabricacao,
                VeiculoId = domain.Veiculo.Id,
                Km = domain.Veiculo.Km,
                ValorCompra = domain.ValorCompra,
                ModeloVeiculo = domain.Veiculo.Modelo,
                ValorRevenda = domain.ValorRevenda,
                ValorTabela = domain.ValorTabela,
                RenavamVeiculo = String.IsNullOrEmpty(domain.Veiculo.Renavam) ? String.Empty : domain.Veiculo.Renavam,
                MarcaVeiculoId = domain.Veiculo.MarcaVeiculo.Id,
                ProprietarioId = domain.Comprador.Id,
                CompradorId = domain.Proprietario.Id,
                SituacaoAquisicaoId = (int)domain.EnumSituacaoAquisicao,
                TipoPagamentoAquisicaoId = (int)domain.EnumTipoPagamentoAquisicao,
                TipoPagamentoRevendaId = (int)domain.EnumTipoPagamentoRevenda,
                DataRevenda = domain.DataRevenda,
                Exclusao = domain.Exclusao
            };
        }
    }
}
