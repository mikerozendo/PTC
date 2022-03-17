﻿using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using System;
using System.Data;

namespace PTC.Infrastructure.Data
{
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        public int Incluir(Endereco obj)
        {
            AddParametro("@Logradouro", SqlDbType.VarChar, obj.Logradouro);
            AddParametro("@Numero", SqlDbType.VarChar, obj.Numero);
            AddParametro("@Bairro", SqlDbType.VarChar, obj.Bairro);
            AddParametro("@Cep", SqlDbType.VarChar, obj.Cep);
            AddParametro("@Uf", SqlDbType.VarChar, obj.Uf);

            var tabela = ExecutarProcedure("P_ENDERECO_INCLUIR");
            return Convert.ToInt32(tabela.Rows[0]);
        }

        public int ExcluirPorId(int id)
        {
            AddParametro("@Id", SqlDbType.VarChar, id);
            ExecutarProcedure("P_ENDERECO_EXCLUIR_POR_ID");
            return id;
        }

        public Endereco ObterPorIdProprietario(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
