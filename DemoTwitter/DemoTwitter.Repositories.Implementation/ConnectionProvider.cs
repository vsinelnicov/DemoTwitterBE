using System.ComponentModel.Composition;
using System.Data;
using System.Data.SqlClient;

namespace DemoTwitter.Repositories.Implementation
{
    [Export(typeof(IConnectionProvider))]
    public class ConnectionProvider : IConnectionProvider
    {
        public ConnectionProvider(IConfigReader configReader)
        {
            ConfigReader = configReader;
        }

        private readonly IConfigReader ConfigReader;

        public IDbConnection CreateMainDatabaseConnection()
        {
            return CreateSqlConnection(ConfigReader.DatabaseConnectionString);
        }

        private IDbConnection CreateSqlConnection(string connString)
        {
            IDbConnection dbConnection = new SqlConnection(connString);
            return dbConnection;
        }

    }
}
