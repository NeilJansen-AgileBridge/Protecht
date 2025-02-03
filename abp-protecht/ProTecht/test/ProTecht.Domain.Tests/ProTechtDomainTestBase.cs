using Volo.Abp.Modularity;

namespace ProTecht;

/* Inherit from this class for your domain layer tests. */
public abstract class ProTechtDomainTestBase<TStartupModule> : ProTechtTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
