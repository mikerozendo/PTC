using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Infrastructure.Data.Base;
using PTC.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;

namespace PTC.Infrastructure.Data.Respository
{
    public class MarcasRepository : BaseRepository, IMarcasRepository
    {
        public MarcasRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<Marca>> ObterTodos()
        {
            List<Marca> marcas = new();
            var tabela = await ExecutarProcedureAsync("P_MARCA_OBTER");

            foreach (DataRow sdr in tabela.Rows)
            {
                marcas.Add(new()
                {
                    Id = Convert.ToInt32(sdr["Id"]),
                    Nome = sdr["Nome"].ToString(),
                    UrlImagem = sdr["CaminhoImagem"].ToString(),
                    Cadastro = Convert.ToDateTime(sdr["Cadastro"]),
                    Exclusao = sdr["Exclusao"] is DBNull ? null : Convert.ToDateTime(sdr["Exclusao"])
                });
            }

            return marcas;
        }

        public async Task<Marca> ObterPorId(int id)
        {
            try
            {
                AddParametro("Id", id);
                var tabela = await ExecutarProcedureAsync("P_MARCA_OBTER_POR_ID");

                return new()
                {
                    Id = id,
                    Nome = tabela.Rows[0]["Nome"].ToString(),
                    UrlImagem = tabela.Rows[0]["CaminhoImagem"].ToString(),
                    Cadastro = Convert.ToDateTime(tabela.Rows[0]["Cadastro"]),
                    Exclusao = DateTime.TryParse(tabela.Rows[0]["Exclusao"].ToString().AsSpan(), out DateTime value) ? value : null
                };
            }
            catch (Exception)
            {
                return new();
            }
        }

        public async Task<bool> Existe(Marca obj)
        {
            AddParametro("Nome", obj.Nome);
            var response = await ExecutarProcedureAsync("P_MARCA_EXISTE");
            return response.Rows.Count > 0;
        }

        public async Task<int> Inserir(Marca obj)
        {
            AddParametro("Nome", obj.Nome);
            AddParametro("Url", obj.UrlImagem);

            var tabela = await ExecutarProcedureAsync("P_MARCA_INSERIR");

            int.TryParse(tabela.Rows[0]["MarcaId"].ToString(), out int marcaId);
            return marcaId;
        }

        public async Task Alterar(Marca obj)
        {
            AddParametro("Nome", obj.Nome);
            AddParametro("Id", obj.Id);
            AddParametro("Url", obj.UrlImagem);
            await ExecutarProcedureAsync("P_MARCA_ALTERAR");
        }

        public async Task Deletar(Marca obj)
        {
            AddParametro("Id", obj.Id);
            await ExecutarProcedureAsync("P_MARCA_DELETAR");
        }     
    }
}
