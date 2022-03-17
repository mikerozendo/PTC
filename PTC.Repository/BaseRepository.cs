using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PTC.Repository
{
    public abstract class BaseRepository
    {
        private readonly string _connectionString;
        protected IList<Parametro> _parametros;

        protected BaseRepository()
        {
            _connectionString = "";
            _parametros = new List<Parametro>();
        }

        protected DataTable ExecutarProcedure(string procedure)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(procedure, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                string sqlquery = procedure;
                foreach (var parametro in _parametros)
                {
                    cmd.Parameters.Add(parametro.Nome, parametro.Tipo).Value = parametro.Valor;
                    sqlquery += "" + parametro.Nome + " = " + $@"'{parametro.Valor}', ";
                }

                 _parametros.Clear();

                con.Open();

                using (var dataReader = cmd.ExecuteReader())
                {
                    var tabela = new DataTable();
                    tabela.Load(dataReader);

                    return tabela;
                }
            }
        }
   
        protected void AddParametro<TDataType>(string nome, SqlDbType tipo, TDataType valor)
        {
            _parametros.Add(new Parametro<TDataType>(nome, tipo, valor));
        }
        protected void ClearParametros()
        {
            _parametros.Clear();
        }
    }
}
