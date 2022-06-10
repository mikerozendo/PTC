using PTC.Domain.Entities;
using PTC.Application.Dtos;

namespace PTC.Application.Mapper
{
    public static class ProprietarioMapper
    {
        public static Proprietario ToDomain(ProprietarioViewModel viewModel)
        {
            return new Proprietario
            {
                Endereco = new Endereco
                {
                    Logradouro = viewModel.Logradouro,
                    Numero = viewModel.Numero,
                    Bairro = viewModel.Bairro,
                    Cep = viewModel.Cep,
                    Uf = viewModel.Uf,
                    PontoReferencia = viewModel.PontoReferencia,
                    Cidade = viewModel.Cidade
                },
                Nome = viewModel.Nome,
                WhatsApp = viewModel.WhatsApp,
                Cadastro = viewModel.Cadastro,
                Exclusao = viewModel.Exclusao,
                Email = viewModel.Email,
                Documento = viewModel.Documento,
                CaminhoImagem = viewModel.CaminhoImagem          
            };
        }
    }
}

