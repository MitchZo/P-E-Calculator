using System.Configuration;

namespace KTC_Scraper
{
    public class ConnectionString : IConnectionString
    {
        public static string ConnectionStringVal(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

    }
}
