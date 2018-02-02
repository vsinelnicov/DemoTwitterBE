using System;
using System.Data;
using System.Data.SqlClient;
using DemoTwitter.Repositories;

namespace DemoTwitter.WebApi.Repository
{
    public class DapperContext : IDisposable
    {

        public DapperContext(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }
        private readonly IConnectionProvider connectionProvider;
        private readonly IDbConnection databaseConnection;

        public DapperContext()
        {
            databaseConnection = connectionProvider.CreateMainDatabaseConnection();
            databaseConnection.Open();
        }

        public void Dispose()
        {
            databaseConnection.Close();
            databaseConnection.Dispose();
        }
    }
}