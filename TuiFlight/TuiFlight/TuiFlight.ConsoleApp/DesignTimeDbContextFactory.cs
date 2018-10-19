using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TuiFlightDataContext;

namespace TuiFlight.ConsoleApp
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TuiFlightDbContext>
    {
        public TuiFlightDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<TuiFlightDbContext>();
            var connectionString = configuration.GetConnectionString("TuiFlightContext");
            //var connectionString = @"Server=(localdb)\mssqllocaldb;Database=TuiFlightDb;Trusted_Connection=True;ConnectRetryCount=0";
            builder.UseSqlServer(connectionString);
            return new TuiFlightDbContext(builder.Options);
        }
    }
}
