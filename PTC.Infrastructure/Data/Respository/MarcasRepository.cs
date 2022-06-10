using System;
using System.Data;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Infrastructure.Data.Base;
using PTC.Domain.Interfaces.Repository;

namespace PTC.Infrastructure.Data.Respository
{
    public class MarcasRepository : BaseRepository, IMarcasRepository
    {
        public IEnumerable<Marca> ObterTodos()
        {
            List<Marca> marcas = new();
            var tabela = ExecutarProcedure("P_MARCA_OBTER");

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

        public Marca ObterPorId(int id)
        {
            try
            {
                AddParametro("Id", id);
                var tabela = ExecutarProcedure("P_MARCA_OBTER_POR_ID");

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

        public bool Existe(Marca obj)
        {
            AddParametro("Nome", obj.Nome);
            return ExecutarProcedure("P_MARCA_EXISTE").Rows.Count > 0;
        }

        public dynamic Inserir(Marca obj)
        {
            AddParametro("Nome", obj.Nome);
            AddParametro("Url", obj.UrlImagem);
            ExecutarProcedure("P_MARCA_INSERIR");
            return "Marca cadastrada com sucesso!";
        }

        public void Alterar(Marca obj)
        {
            AddParametro("Nome", obj.Nome);
            AddParametro("Id", obj.Id);
            AddParametro("Url", obj.UrlImagem);
            ExecutarProcedure("P_MARCA_ALTERAR");
        }

        public void Deletar(Marca obj)
        {
            AddParametro("Id", obj.Id);
            ExecutarProcedure("P_MARCA_DELETAR");
        }     
    }
}
