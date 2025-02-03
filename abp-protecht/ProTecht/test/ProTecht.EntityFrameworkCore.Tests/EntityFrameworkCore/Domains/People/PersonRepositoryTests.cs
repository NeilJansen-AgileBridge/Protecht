using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using ProTecht.People;
using ProTecht.EntityFrameworkCore;
using Xunit;

namespace ProTecht.EntityFrameworkCore.Domains.People
{
    public class PersonRepositoryTests : ProTechtEntityFrameworkCoreTestBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonRepositoryTests()
        {
            _personRepository = GetRequiredService<IPersonRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _personRepository.GetListAsync(
                    personId: Guid.Parse("515a87ec-0fff-4152-967c-16234bba6fb9"),
                    name: "99b3a4cd7f8145ef9f64c02f08",
                    surname: "975c9138abdc4727a4ae852906b53360b35968dff0e94deca81603974de57985da1bb9358f9e484",
                    contactNumber: "14890d739acb42928d4c8a0effbeca",
                    vehicleRegistration: "53374d45bcd1469aa",
                    vehicleType: "06b6a3b998184b508925"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("86d5ec58-5d11-451b-b95c-dc601b536e9b"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _personRepository.GetCountAsync(
                    personId: Guid.Parse("73e12316-254a-492f-94f7-28c5dd4cbed1"),
                    name: "95b40b3a32dd485",
                    surname: "e982837e47414bed8a1bf865e1bec20cb7afebfc2c28489d958c2a3d0c66e47ab1",
                    contactNumber: "f7aff854f5c84a72b7c8d2c1eb",
                    vehicleRegistration: "71f9221b207c4b409bf6884ba1895d6f94df58b47d9d44bf",
                    vehicleType: "baea7e6a2be449c0876bdbb92c83f9ca6a66e7f2688d4496b9ff8399fdbe67f1615b1ce90d2d4f75b6cdf810dddd25"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}