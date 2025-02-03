using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ProTecht.Data;

/* This is used if database provider does't define
 * IProTechtDbSchemaMigrator implementation.
 */
public class NullProTechtDbSchemaMigrator : IProTechtDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
