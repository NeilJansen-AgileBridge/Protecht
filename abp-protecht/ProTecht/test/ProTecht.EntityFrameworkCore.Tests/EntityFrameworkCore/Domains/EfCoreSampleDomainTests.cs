using ProTecht.Samples;
using Xunit;

namespace ProTecht.EntityFrameworkCore.Domains;

[Collection(ProTechtTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ProTechtEntityFrameworkCoreTestModule>
{

}
