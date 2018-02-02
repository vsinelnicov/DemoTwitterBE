using System.Data;

namespace DemoTwitter.Repositories
{
    public interface IConnectionProvider
    {
        IDbConnection CreateMainDatabaseConnection();
    }
}
