using System;
using System.Data;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Domain.Enums;
using PTC.Infrastructure.Data.Base;
using PTC.Domain.Interfaces.Repository;

namespace PTC.Infrastructure.Data.Respository
{
    public class VeiculosRepository : BaseRepository, IVeiculosRepository
    {
        public void Alterar(Veiculo obj)
        {
            AddParametro("ProprietarioId", obj.Proprietario.Id);
            AddParametro("Renavam", obj.Renavam);
            AddParametro("MarcaVeiculo", obj.MarcaVeiculo.Id);
            AddParametro("Modelo", obj.Modelo);
            AddParametro("DataFabricacao", obj.DataFabricacao);
            AddParametro("Km", obj.Km);
            AddParametro("Valor", obj.Valor);
            AddParametro("Situacao", obj.EnumSituacao);
            ExecutarProcedure("P_VEICULO_ALTERAR");
        }

        public dynamic Inserir(Veiculo obj)
        {
            AddParametro("ProprietarioId", obj.Proprietario.Id);
            AddParametro("Renavam", obj.Renavam);
            AddParametro("MarcaVeiculo", obj.MarcaVeiculo.Id);
            AddParametro("Modelo", obj.Modelo);
            AddParametro("DataFabricacao", obj.DataFabricacao);
            AddParametro("Km", obj.Km);
            AddParametro("Valor", obj.Valor);
            AddParametro("Situacao", obj.EnumSituacao);
            ExecutarProcedure("P_VEICULO_INSERIR");
            return "Veiculo inserido com sucesso!";
        }

        public IEnumerable<Veiculo> ObterTodos()
        {
            List<Veiculo> veiculos = new();
            var tabela = ExecutarProcedure("P_VEICULO_OBTER_TODOS");

            foreach (DataRow sdr in tabela.Rows)
            {
                veiculos.Add(new()
                {
                    Id = Convert.ToInt32(sdr["Id"]),
                    AnoModelo = Convert.ToDateTime(sdr["AnoModelo"]),
                    Cadastro = Convert.ToDateTime(sdr["Cadastro"]),
                    DataFabricacao = Convert.ToDateTime(sdr["DataFabricacao"]),
                    Exclusao = Convert.ToDateTime(sdr["Exclusao"]),
                    EnumSituacao = (EnumSituacao)sdr["Situacao"],
                    Km = sdr["Km"].ToString(),
                    Modelo = sdr["Modelo"].ToString(),
                    Renavam = sdr["Renavam"].ToString(),
                    Valor = Convert.ToDecimal(sdr["Valor"]),
                    Proprietario = new()
                    {
                        Id = Convert.ToInt32(sdr["IdProprietario"]),
                        Nome = sdr["NomeProprietario"].ToString(),
                    },
                    MarcaVeiculo = new()
                    {
                        Nome = sdr["NomeMarca"].ToString(),
                        UrlImagem = sdr["CaminhoImagem"].ToString(),                       
                    }
                });
            }

            return veiculos;
        }

        public void Deletar(Veiculo obj)
        {
            return;
        }
    }
}
