using Volo.Abp.Modularity;

namespace ProTecht;

public abstract class ProTechtApplicationTestBase<TStartupModule> : ProTechtTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
