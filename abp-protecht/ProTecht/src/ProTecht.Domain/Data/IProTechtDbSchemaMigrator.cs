using System.Threading.Tasks;

namespace ProTecht.Data;

public interface IProTechtDbSchemaMigrator
{
    Task MigrateAsync();
}
