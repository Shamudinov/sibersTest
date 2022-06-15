using Microsoft.Extensions.Configuration;
using System.IO;

namespace SibersTest.DAL.DbContext
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var connection = root.GetSection("ConnectionStrings:DefaultConnection");
            sqlConnectionString = connection.Value;
        }

        public string sqlConnectionString { get; private set; }
    }
}
