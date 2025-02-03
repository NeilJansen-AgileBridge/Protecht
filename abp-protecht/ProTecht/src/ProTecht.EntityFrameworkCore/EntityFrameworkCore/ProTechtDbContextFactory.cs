using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ProTecht.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ProTechtDbContextFactory : IDesignTimeDbContextFactory<ProTechtDbContext>
{
    public ProTechtDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        ProTechtEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<ProTechtDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new ProTechtDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ProTecht.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
