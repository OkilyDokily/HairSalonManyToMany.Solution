using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using HairSalonManyToMany.Models;
using System.IO;

namespace ToDoList.Models
{
  public class HairSalonManyToManyContextFactory : IDesignTimeDbContextFactory<HairSalonManyToManyContext>
  {

    HairSalonManyToManyContext IDesignTimeDbContextFactory<HairSalonManyToManyContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<HairSalonManyToManyContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new HairSalonManyToManyContext(builder.Options);
    }
  }
}