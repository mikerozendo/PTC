﻿using System;
using PTC.Domain.Entities;
using PTC.Infrastructure.Data.Base;
using PTC.Domain.Interfaces.Repository;

namespace PTC.Infrastructure.Data.Respository
{
    public class OperacaoRepository : BaseRepository, IOperacaoRepository
    {
        public void Alterar(Operacao obj)
        {
            throw new System.NotImplementedException();
        }

        public void Deletar(Operacao obj)
        {
            throw new System.NotImplementedException();
        }

        public dynamic Inserir(Operacao obj)
        {
            AddParametro("IdVeiculo", obj.Veiculo.Id);
            AddParametro("IdProprietario", obj.Proprietario.Id);
            AddParametro("IdComprador", obj.Comprador.Id);
            AddParametro("SituacaoAquisicao", obj.EnumSituacaoAquisicao);
            AddParametro("FormaPagamentoAquisicao", obj.EnumTipoPagamentoAquisicao);
            AddParametro("FormaPagamentoRevenda", obj.EnumTipoPagamentoRevenda);
            AddParametro("Compra", obj.Cadastro);
            AddParametro("Revenda", obj.DataRevenda);
            AddParametro("Cadastro", DateTime.Now);
            var tabela = ExecutarProcedure("P_OPERACAO_INSERIR");
            return tabela.Rows.Count;
        }
    }
}