using PTC.Domain.Entities;
using PTC.Application.Dtos;

namespace PTC.Application.Mapper
{
    public static class ProprietarioMapper
    {
        public static Proprietario ToDomain(ProprietarioViewModel viewModel)
        {
            return new Proprietario(viewModel.Documento)
            {
                Id = viewModel.Id,
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
                CaminhoImagem = viewModel.CaminhoImagem
            };
        }

        public static ProprietarioViewModel ToViewModel(Proprietario domain, int numeradorPagina = 1)
        {
            return new ProprietarioViewModel
            {
                Logradouro = domain.Endereco.Logradouro,
                Numero = domain.Endereco.Numero,
                Bairro = domain.Endereco.Bairro,
                Cep = domain.Endereco.Cep,
                Uf = domain.Endereco.Uf,
                PontoReferencia = domain.Endereco.PontoReferencia,
                Cidade = domain.Endereco.Cidade,
                Nome = domain.Nome,
                WhatsApp = domain.WhatsApp,
                Cadastro = domain.Cadastro,
                Exclusao = domain.Exclusao,
                Email = domain.Email,
                Documento = domain.Documento.Numero,
                CaminhoImagem = domain.CaminhoImagem,
                Id = domain.Id,
                NumeradorPagina = numeradorPagina
            };
        }
    }
}

