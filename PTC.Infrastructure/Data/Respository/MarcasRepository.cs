using System;
using System.Data;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Domain.Enums;
using PTC.Domain.Interfaces.Repository;
using PTC.Infrastructure.Data.Base;

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
                    EnumSituacao = (EnumSituacao)sdr["Situacao"],
                    Nome = sdr["Nome"].ToString()
                });
            }

            return marcas;
        }

        public dynamic Inserir(Marca obj)
        {
            List<Marca> marcas = new();
            AddParametro("Nome", obj.Nome);

            var tabela = ExecutarProcedure("P_MARCA_INSERIR");

            foreach (DataRow sdr in tabela.Rows)
            {
                marcas.Add(new()
                {
                    EnumSituacao = (EnumSituacao)sdr["Situacao"],
                    Id = Convert.ToInt32(sdr["Id"]),
                    Nome = sdr["Nome"].ToString()
                });
            }

            return marcas;
        }

        public void Alterar(Marca obj)
        {
            AddParametro("Nome", obj.Nome);
            AddParametro("Id", obj.Id);
            AddParametro("Status", obj.EnumSituacao);
            ExecutarProcedure("P_MARCA_ALTERAR");
        }

        public void Deletar(Marca obj)
        {
            Alterar(obj);
        }
    }
}
