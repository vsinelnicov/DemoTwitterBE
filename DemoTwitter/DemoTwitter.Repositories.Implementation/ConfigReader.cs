using System.ComponentModel.Composition;
using System.Configuration;

namespace DemoTwitter.Repositories.Implementation
{
    [Export(typeof(IConfigReader))]
    public class ConfigReader : IConfigReader
    {
        public string DatabaseConnectionString
            => ConfigurationManager.ConnectionStrings["Twitter_dbEntities"].ConnectionString;
    }
}
