using Volo.Abp.Modularity;

namespace ProTecht;

[DependsOn(
    typeof(ProTechtDomainModule),
    typeof(ProTechtTestBaseModule)
)]
public class ProTechtDomainTestModule : AbpModule
{

}
