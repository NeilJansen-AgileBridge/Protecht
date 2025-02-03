using Xunit;

namespace ProTecht.EntityFrameworkCore;

[CollectionDefinition(ProTechtTestConsts.CollectionDefinitionName)]
public class ProTechtEntityFrameworkCoreCollection : ICollectionFixture<ProTechtEntityFrameworkCoreFixture>
{

}
