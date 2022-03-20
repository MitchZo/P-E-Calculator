using System.Configuration;

namespace KTC_Scraper
{
    public static class ConnectionString
    {
        public static string ConnectionStringVal(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

    }
}
