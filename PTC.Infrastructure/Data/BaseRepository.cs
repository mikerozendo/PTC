using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PTC.Infrastructure.Data
{
    public abstract class BaseRepository
    {
        private readonly string _connectionString;
        protected IList<Parametro> _parametros;

        protected BaseRepository()
        {
            //_connectionString = "Server=localhost; Port=3306; Database=ptc; User=dev; Password=@M1ke98!;";
            _connectionString = "Server=127.0.0.1; Database=ptc; User=root; Password=@M1ke98!;";

            _parametros = new List<Parametro>();
        }

        protected DataTable ExecutarProcedure(string procedure)
        {
            try
            {

                using (var con = new MySqlConnection(_connectionString))
                using (var cmd = new MySqlCommand())
                {
                    cmd.CommandText = procedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Connection = con;
                    //string sqlquery = $"CALL {procedure} (";
                    foreach (var parametro in _parametros)
                    {
                        cmd.Parameters.AddWithValue($@"{parametro.Nome}", parametro.Valor).Direction = ParameterDirection.Input;

                        //cmd.Parameters.Add(parametro.Nome, ,parametro.Tipo).Value = parametro.Valor;
                        // cmd.Parameters.Add(parametro.Nome, parametro.Tipo).Value = parametro.Valor;
                        //sqlquery += "" + parametro.Nome + " = " + $@"'{parametro.Valor}', ";
                    }
                    //cmd.CommandText = sqlquery.Substring(0,sqlquery.Length - 2) + ")";
                    //cmd.CommandText = sqlquery;
                    
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
            catch (System.Exception ex)
            {
                throw;
            }
        }

        protected void AddParametro<TDataType>(string nome, TDataType valor)
        {
            _parametros.Add(new Parametro<TDataType>(nome, valor));
        }

        protected void ClearParametros()
        {
            _parametros.Clear();
        }
    }
}
