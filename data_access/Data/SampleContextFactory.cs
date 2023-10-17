using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data
{
    //For creating a connection using a json resource file
    //public class SampleContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    //{
    //    public ApplicationContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

    //        ConfigurationBuilder builder = new ConfigurationBuilder();
    //        builder.SetBasePath(Directory.GetCurrentDirectory());
    //        builder.AddJsonFile("appsettings.json");
    //        IConfigurationRoot config = builder.Build();

    //        string connectionString = config.GetConnectionString("MyDbConnection");
    //        optionsBuilder.UseSqlServer(connectionString);
    //        return new ApplicationContext(optionsBuilder.Options);
    //    }
    //}
}
