using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseApplicationDbcontext>
{
    public DatabaseApplicationDbcontext CreateDbContext(string[]args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<DatabaseApplicationDbcontext>();
        var configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
       .Build();
      var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);

      return new DatabaseApplicationDbcontext(optionsBuilder.Options);
    }
}