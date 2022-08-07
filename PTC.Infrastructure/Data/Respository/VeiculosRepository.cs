using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PTC.Domain.Entities;
using PTC.Infrastructure.Data.Base;
using PTC.Domain.Interfaces.Repository;

namespace PTC.Infrastructure.Data.Respository
{
    public class VeiculosRepository : BaseRepository, IVeiculosRepository
    {
        public VeiculosRepository(IConfiguration configuration) : base(configuration) { }

        public async Task Alterar(Veiculo obj)
        {
            AddParametro("Renavam", obj.Renavam);
            AddParametro("MarcaVeiculo", obj.MarcaVeiculo.Id);
            AddParametro("Modelo", obj.Modelo);
            AddParametro("DataFabricacao", obj.DataFabricacao);
            AddParametro("Km", obj.Km);
            await ExecutarProcedureAsync("P_VEICULO_ALTERAR");
        }

        public async Task<int> Inserir(Veiculo obj)
        {
            AddParametro("Km", obj.Km);
            AddParametro("Modelo", obj.Modelo);
            AddParametro("Renavam", obj.Renavam);
            AddParametro("Nome", obj.Nome);
            AddParametro("DataFabricacao", obj.DataFabricacao);
            AddParametro("MarcaVeiculoId", obj.MarcaVeiculo.Id);

            var dbResponse = await ExecutarProcedureAsync("P_VEICULO_INSERIR");
            int.TryParse(dbResponse.Rows[0]["Id"].ToString(), out int response);
            return response;
        }

        public async Task<IEnumerable<Veiculo>> ObterTodos()
        {
            List<Veiculo> veiculos = new();
            var tabela = await ExecutarProcedureAsync("P_VEICULO_OBTER_TODOS");

            foreach (DataRow sdr in tabela.Rows)
            {
                veiculos.Add(new()
                {
                    Id = Convert.ToInt32(sdr["Id"]),
                    Cadastro = Convert.ToDateTime(sdr["Cadastro"]),
                    DataFabricacao = Convert.ToDateTime(sdr["DataFabricacao"]),
                    Exclusao = Convert.ToDateTime(sdr["Exclusao"]),
                    Km = (decimal)sdr["Km"],
                    Modelo = sdr["Modelo"].ToString(),
                    Renavam = sdr["Renavam"].ToString(),
                    MarcaVeiculo = new()
                    {
                        Nome = sdr["NomeMarca"].ToString(),
                        UrlImagem = sdr["CaminhoImagem"].ToString(),
                    }
                });
            }

            return veiculos;
        }

        public async Task Deletar(Veiculo obj)
        {
            AddParametro("Id", obj.Id);
            await ExecutarProcedureAsync("P_VEICULO_DELETAR");
        }
    }
}
