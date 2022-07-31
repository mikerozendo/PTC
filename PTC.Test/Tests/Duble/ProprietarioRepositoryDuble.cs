using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTC.Test.Tests.Duble
{
    public class ProprietarioRepositoryDuble : IProprietarioRepository
    {
        public List<Proprietario> proprietarios = new()
        {
            //new Proprietario { Id = 34, Nome = "Teste1", Documento = "44.436.599/0001-86" },
            //new Proprietario { Id = 35, Nome = "Teste2", Documento = "44.436.599/0001-82" },
            //new Proprietario { Id = 37, Nome = "Teste3", Documento = "44.436.599/0001-82" },
            //new Proprietario { Id = 38, Nome = "Teste4", Documento = "44.436.499/0001-82" },
            //new Proprietario { Id = 39, Nome = "Teste5", Documento = "44.436.699/0001-82" }
        };

        public Task Alterar(Proprietario obj)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(Proprietario obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Existe(Proprietario obj)
        {
            return Task.Run(() => (proprietarios.FirstOrDefault(x => x.Documento == obj.Documento)) is null ? false : true);
        }

        public Task<int> Inserir(Proprietario obj)
        {
            throw new NotImplementedException();
        }

        public Task<Proprietario> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Proprietario>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
