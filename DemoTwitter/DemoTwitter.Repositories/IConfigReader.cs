namespace DemoTwitter.Repositories
{
    public interface IConfigReader
    {
        string DatabaseConnectionString { get; }
    }
}
