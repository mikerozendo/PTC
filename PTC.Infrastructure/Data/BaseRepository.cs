using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace PTC.Infrastructure.Data
{
    public abstract class BaseRepository
    {
        private readonly string _connectionString;
        protected IList<Parametro> _parametros;

        protected BaseRepository()
        {
            _connectionString = "Server=127.0.0.1; Database=ptc; User=root; Password=@M1ke98!;";
            _parametros = new List<Parametro>();
        }

        protected DataTable ExecutarProcedure(string procedure)
        {
            try
            {

                using (var conn = new MySqlConnection(_connectionString))
                using (var cmd = new MySqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 300
                })
                {
                    foreach (var parametro in _parametros)
                        cmd.Parameters.AddWithValue($@"{parametro.Nome}", parametro.Valor).Direction = ParameterDirection.Input;

                    _parametros.Clear();
                    conn.Open();

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
