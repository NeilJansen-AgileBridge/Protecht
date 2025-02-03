using ProTecht.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ProTecht.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProTechtEntityFrameworkCoreModule),
    typeof(ProTechtApplicationContractsModule)
)]
public class ProTechtDbMigratorModule : AbpModule
{
}
