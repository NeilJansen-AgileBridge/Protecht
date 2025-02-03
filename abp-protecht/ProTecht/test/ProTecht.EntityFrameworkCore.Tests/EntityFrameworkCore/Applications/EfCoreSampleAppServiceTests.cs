using ProTecht.Samples;
using Xunit;

namespace ProTecht.EntityFrameworkCore.Applications;

[Collection(ProTechtTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ProTechtEntityFrameworkCoreTestModule>
{

}
