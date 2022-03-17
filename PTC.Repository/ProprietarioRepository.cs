using System;
using System.Collections.Generic;
using System.Text;
using PTC.Repository.Interfaces;
using PTC.Domain.Entities;
using System.Data;

namespace PTC.Repository
{
    public class ProprietarioRepository : BaseRepository, IProprietarioRepository
    {
        public bool Existe(Proprietario obj)
        {
            AddParametro("@Nome", SqlDbType.VarChar, obj.Nome);
            AddParametro("@Documento", SqlDbType.VarChar, obj.Documento);
            var tabela = ExecutarProcedure("P_PROPRIETARIO_EXISTE");

            return tabela.Rows.Count > 0 ? true : false;
        }
    }
}
