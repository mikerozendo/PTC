﻿using System;
using System.Data;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Domain.Enums;
using PTC.Domain.Interfaces.Repository;
using PTC.Infrastructure.Data.Base;

namespace PTC.Infrastructure.Data.Respository
{
    public class ProprietarioRepository : BaseRepository, IProprietarioRepository
    {
        public bool Existe(Proprietario obj)
        {
            AddParametro("Documento", obj.Documento);
            return ExecutarProcedure("P_PROPRIETARIO_EXISTE").Rows.Count > 0;
        }

        public dynamic Inserir(Proprietario obj)
        {
            AddParametro("Nome", obj.Nome);
            AddParametro("Documento", obj.Documento);
            AddParametro("Email", obj.Email);
            AddParametro("IdEndereco", obj.Endereco.Id);
            AddParametro("WhatsApp", obj.WhatsApp);
            AddParametro("CaminhoImagem", obj.CaminhoImagem);
            ExecutarProcedure("P_PROPRIETARIO_INCLUIR");
            return "Proprietário Cadastrado com sucesso!";
        }

        public IEnumerable<Proprietario> ObterTodos()
        {
            List<Proprietario> proprietarios = new();
            var tabela = ExecutarProcedure("P_PROPRIETARIO_OBTER_TODOS");

            foreach (DataRow sdr in tabela.Rows)
            {
                proprietarios.Add(new Proprietario
                {
                    Documento = sdr["Documento"].ToString(),
                    Email = sdr["Email"].ToString(),
                    EnumSituacaoProprietario = Convert.ToBoolean(sdr["Ativo"]) ? EnumSituacao.Ativo : EnumSituacao.Inativo,
                    EnumTipoPessoa = (EnumTipoPessoa)sdr["IdTipoPessoa"],
                    Id = Convert.ToInt32(sdr["Id"]),
                    Nome = sdr["Nome"].ToString(),
                    WhatsApp = sdr["WhatsApp"].ToString(),
                    Cadastro = Convert.ToDateTime(sdr["Cadastro"]),
                    Exclusao = sdr["Exclusao"] is DBNull ? null : Convert.ToDateTime(sdr["Exclusao"]),
                    CaminhoImagem = sdr["CaminhoImagem"] is DBNull ? null : sdr["CaminhoImagem"].ToString(),
                    Endereco = new Endereco
                    {
                        Bairro = sdr["Bairro"].ToString(),
                        Cep = sdr["Cep"].ToString(),
                        Logradouro = sdr["Logradouro"].ToString(),
                        Numero = sdr["Numero"].ToString(),
                        Uf = sdr["Uf"].ToString(),
                        Cidade = sdr["Cidade"].ToString()                        
                    }
                });
            }

            return proprietarios;
        }

        public void Alterar(Proprietario obj)
        {
            AddParametro("Id", obj.Id);
            AddParametro("Nome", obj.Nome);
            AddParametro("Documento", obj.Documento);
            AddParametro("Email", obj.Email);
            AddParametro("WhatsApp", obj.WhatsApp);
            AddParametro("CaminhoImagem", obj.CaminhoImagem);
            ExecutarProcedure("P_PROPRIETARIO_ALTERAR");
        }

        public void Deletar(Proprietario obj)
        {
            AddParametro("Id", obj.Id);
            ExecutarProcedure("P_PROPRIETARIO_DELETAR");
        }

        public Proprietario ObterPorId(int id)
        {
            AddParametro("Id", id);
            var tabela = ExecutarProcedure("P_PROPRIETARIO_OBTER_POR_ID");

            return new Proprietario
            {
                Documento = tabela.Rows[0]["Documento"].ToString(),
                Email = tabela.Rows[0]["Email"].ToString(),
                EnumSituacaoProprietario = Convert.ToBoolean(tabela.Rows[0]["Ativo"]) ? EnumSituacao.Ativo : EnumSituacao.Inativo,
                EnumTipoPessoa = (EnumTipoPessoa)tabela.Rows[0]["IdTipoPessoa"],
                Id = Convert.ToInt32(tabela.Rows[0]["Id"]),
                Nome = tabela.Rows[0]["Nome"].ToString(),
                WhatsApp = tabela.Rows[0]["WhatsApp"].ToString(),
                Cadastro = Convert.ToDateTime(tabela.Rows[0]["Cadastro"]),
                Exclusao = tabela.Rows[0]["Exclusao"] is DBNull ? null : Convert.ToDateTime(tabela.Rows[0]["Exclusao"]),
                CaminhoImagem = tabela.Rows[0]["CaminhoImagem"] is DBNull ? null : tabela.Rows[0]["CaminhoImagem"].ToString(),
                Endereco = new Endereco
                {
                    Bairro = tabela.Rows[0]["Bairro"].ToString(),
                    Cep = tabela.Rows[0]["Cep"].ToString(),
                    Logradouro = tabela.Rows[0]["Logradouro"].ToString(),
                    Numero = tabela.Rows[0]["Numero"].ToString(),
                    Uf = tabela.Rows[0]["Uf"].ToString(),
                    Cidade = tabela.Rows[0]["Cidade"].ToString(),
                }
            };
        }
    }
}
