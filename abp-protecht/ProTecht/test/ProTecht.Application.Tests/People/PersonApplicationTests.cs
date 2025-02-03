using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace ProTecht.People
{
    public abstract class PeopleAppServiceTests<TStartupModule> : ProTechtApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IPeopleAppService _peopleAppService;
        private readonly IRepository<Person, Guid> _personRepository;

        public PeopleAppServiceTests()
        {
            _peopleAppService = GetRequiredService<IPeopleAppService>();
            _personRepository = GetRequiredService<IRepository<Person, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _peopleAppService.GetListAsync(new GetPeopleInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("86d5ec58-5d11-451b-b95c-dc601b536e9b")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("cd3946e7-f748-4987-949f-6bfa26d44024")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _peopleAppService.GetAsync(Guid.Parse("86d5ec58-5d11-451b-b95c-dc601b536e9b"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("86d5ec58-5d11-451b-b95c-dc601b536e9b"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new PersonCreateDto
            {
                PersonId = Guid.Parse("ec6fc6a7-6a27-4649-8646-ec52c2391709"),
                Name = "f35b6a5b62ec4cf2b5a1c06851e9ca01d571ab6330e34986abc0",
                Surname = "bf33eda7403c443da8e4a3f1da627e2b33628e1bf8814305bef084ea2d6f871",
                ContactNumber = "9e7b2e1a843448eb87fde4818601ba648e5240a47f40473c",
                VehicleRegistration = "346f9392fe8e4742923b29eb9528675fe4630",
                VehicleType = "7b91b68c79664ce29f742139ba781821614cf2de907c4bc2a5ac0523905c345233a952d9547d406a887c677b8bb",
                Age = 1242280611
            };

            // Act
            var serviceResult = await _peopleAppService.CreateAsync(input);

            // Assert
            var result = await _personRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.PersonId.ShouldBe(Guid.Parse("ec6fc6a7-6a27-4649-8646-ec52c2391709"));
            result.Name.ShouldBe("f35b6a5b62ec4cf2b5a1c06851e9ca01d571ab6330e34986abc0");
            result.Surname.ShouldBe("bf33eda7403c443da8e4a3f1da627e2b33628e1bf8814305bef084ea2d6f871");
            result.ContactNumber.ShouldBe("9e7b2e1a843448eb87fde4818601ba648e5240a47f40473c");
            result.VehicleRegistration.ShouldBe("346f9392fe8e4742923b29eb9528675fe4630");
            result.VehicleType.ShouldBe("7b91b68c79664ce29f742139ba781821614cf2de907c4bc2a5ac0523905c345233a952d9547d406a887c677b8bb");
            result.Age.ShouldBe(1242280611);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new PersonUpdateDto()
            {
                PersonId = Guid.Parse("8ebd250b-f6d1-43de-93e8-a523b64ffb07"),
                Name = "d4c20d67e4194b42bbe281092c016b81986e157d12374f178b49e621e8e63ab400c876a6311a47ed9e0933e",
                Surname = "4d2d37df4b914d1ba6635b221b6ff3910c24410095ca4cee9acfbdf598e969bfb9a6218",
                ContactNumber = "420a32654ff74028aecd296d55e548af84672e476a344e448f6e8da958545dddf03694f333d144b686e92b8903c998",
                VehicleRegistration = "f582fe68e7a749a0aad0b2b3d1ff018808979799d0d849a4b13cfd2d003219a0bf",
                VehicleType = "bf38ff364ece4fd486f30",
                Age = 1819272746
            };

            // Act
            var serviceResult = await _peopleAppService.UpdateAsync(Guid.Parse("86d5ec58-5d11-451b-b95c-dc601b536e9b"), input);

            // Assert
            var result = await _personRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.PersonId.ShouldBe(Guid.Parse("8ebd250b-f6d1-43de-93e8-a523b64ffb07"));
            result.Name.ShouldBe("d4c20d67e4194b42bbe281092c016b81986e157d12374f178b49e621e8e63ab400c876a6311a47ed9e0933e");
            result.Surname.ShouldBe("4d2d37df4b914d1ba6635b221b6ff3910c24410095ca4cee9acfbdf598e969bfb9a6218");
            result.ContactNumber.ShouldBe("420a32654ff74028aecd296d55e548af84672e476a344e448f6e8da958545dddf03694f333d144b686e92b8903c998");
            result.VehicleRegistration.ShouldBe("f582fe68e7a749a0aad0b2b3d1ff018808979799d0d849a4b13cfd2d003219a0bf");
            result.VehicleType.ShouldBe("bf38ff364ece4fd486f30");
            result.Age.ShouldBe(1819272746);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _peopleAppService.DeleteAsync(Guid.Parse("86d5ec58-5d11-451b-b95c-dc601b536e9b"));

            // Assert
            var result = await _personRepository.FindAsync(c => c.Id == Guid.Parse("86d5ec58-5d11-451b-b95c-dc601b536e9b"));

            result.ShouldBeNull();
        }
    }
}