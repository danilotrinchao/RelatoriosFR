using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace RelatorioFr.ExternalService.DataBase.DbSession
{
    public class DbConnection
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public DbConnection(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DefaultConnection");
        }

        public void ExecuteInTransaction(Action<IDbConnection, IDbTransaction> action)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        action(connection, transaction);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                connection.Close();
            }
        }
    }
}
