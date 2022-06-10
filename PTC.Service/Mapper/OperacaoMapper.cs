using PTC.Domain.Enums;
using PTC.Domain.Entities;
using PTC.Application.Dtos;

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
                    AnoModelo = viewModel.AnoModeloVeiculo,
                    Cadastro = viewModel.Cadastro,
                    CaminhoImagem = viewModel.CaminhoImagem,
                    DataFabricacao = viewModel.DataFabricacaoVeiculo,
                    Exclusao = viewModel.DataFabricacaoVeiculo,
                    Id = viewModel.VeiculoId,
                    Km = viewModel.Km,
                    ValorCompra = viewModel.ValorCompra,
                    Modelo = viewModel.ModeloVeiculo,
                    ValorRevenda = viewModel.ValorRevenda,
                    ValorTabela = viewModel.ValorTabela,
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
                Exclusao = viewModel.Exclusao
            };
        }

        public static OperacaoViewModel ToDomain(Operacao domain)
        {
            return new OperacaoViewModel
            {
                AnoModeloVeiculo = domain.Veiculo.AnoModelo,
                Cadastro = domain.Veiculo.Cadastro,
                CaminhoImagem = domain.Veiculo.CaminhoImagem,
                DataFabricacaoVeiculo = domain.Veiculo.DataFabricacao,
                VeiculoId = domain.Veiculo.Id,
                Km = domain.Veiculo.Km,
                ValorCompra = domain.Veiculo.ValorCompra,
                ModeloVeiculo = domain.Veiculo.Modelo,
                ValorRevenda = domain.Veiculo.ValorRevenda,
                ValorTabela = domain.Veiculo.ValorTabela,
                RenavamVeiculo = domain.Veiculo.Renavam,
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
