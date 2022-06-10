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
                    Cadastro = viewModel.CadastroVeiculo,
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
                Cadastro = viewModel.DataAquisicao                
            };
        }
    }
}
