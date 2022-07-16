using PTC.Application.Services;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using PTC.Domain.Interfaces.Services;
using System;
using Xunit;

namespace PTC.Test.Tests.Services
{
    public class ProprietarioTeste 
    {
        public ProprietarioTeste()
        {

        }

        [Theory]
        [InlineData("Michael", "44.436.599/0001-86", "mikerozendo@gmail.com", "(11) 9 4912-6483", "Padre Justino", "101010", "SP", "São Paulo", "ParqueRegina", "06772-030", "PontoReferencia Teste")]
        public void TestaInsertProprietario(string nome,
            string documento,
            string email,
            string whatsapp,
            string logradouro,
            string numero,
            string uf,
            string cidade,
            string bairro,
            string cep,
            string pontoReferencia)
        {
            var proprietario = new Proprietario
            {
                Nome = nome,
                Documento = documento,
                Email = email,
                WhatsApp = whatsapp,
                Endereco = new Endereco
                {
                    Logradouro = logradouro,
                    Numero = numero,
                    Uf = uf,
                    Cidade = cidade,
                    Bairro = bairro,
                    Cep = cep,
                    PontoReferencia = pontoReferencia
                }
            };


            //var services = new ServiceCollection();
            //var serviceProvider = services.BuildServiceProvider().GetServices(typeof(IProprietarioRepository));

            //var response = new ProprietarioService((IServiceProvider)serviceProvider).Inserir(proprietario).GetAwaiter().GetResult();
            //Assert.Contains("sucesso", response.ToString().ToLower());
        }
    }
}
