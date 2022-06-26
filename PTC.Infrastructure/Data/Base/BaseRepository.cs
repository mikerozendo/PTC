using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace PTC.Infrastructure.Data.Base
{
    public abstract class BaseRepository
    {
        private readonly string _connectionString;
        protected IList<Parametro> _parametros;

        protected BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DatataBase");
            _parametros = new List<Parametro>();
        }

        protected async Task<DataTable> ExecutarProcedureAsync(string procedure)
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
                    await conn.OpenAsync();

                    using (var dataReader = cmd.ExecuteReaderAsync())
                    {
                        var tabela = new DataTable();
                        tabela.Load(await dataReader);
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
