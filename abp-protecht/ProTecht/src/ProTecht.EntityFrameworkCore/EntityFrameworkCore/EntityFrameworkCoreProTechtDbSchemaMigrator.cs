using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProTecht.Data;
using Volo.Abp.DependencyInjection;

namespace ProTecht.EntityFrameworkCore;

public class EntityFrameworkCoreProTechtDbSchemaMigrator
    : IProTechtDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreProTechtDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ProTechtDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ProTechtDbContext>()
            .Database
            .MigrateAsync();
    }
}
