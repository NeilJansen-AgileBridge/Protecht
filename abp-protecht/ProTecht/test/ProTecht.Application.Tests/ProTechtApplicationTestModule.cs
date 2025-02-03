using Volo.Abp.Modularity;

namespace ProTecht;

[DependsOn(
    typeof(ProTechtApplicationModule),
    typeof(ProTechtDomainTestModule)
)]
public class ProTechtApplicationTestModule : AbpModule
{

}
