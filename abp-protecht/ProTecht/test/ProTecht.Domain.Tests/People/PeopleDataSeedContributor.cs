using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using ProTecht.People;

namespace ProTecht.People
{
    public class PeopleDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public PeopleDataSeedContributor(IPersonRepository personRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _personRepository = personRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _personRepository.InsertAsync(new Person
            (
                id: Guid.Parse("86d5ec58-5d11-451b-b95c-dc601b536e9b"),
                personId: Guid.Parse("515a87ec-0fff-4152-967c-16234bba6fb9"),
                name: "99b3a4cd7f8145ef9f64c02f08",
                surname: "975c9138abdc4727a4ae852906b53360b35968dff0e94deca81603974de57985da1bb9358f9e484",
                contactNumber: "14890d739acb42928d4c8a0effbeca",
                vehicleRegistration: "53374d45bcd1469aa",
                vehicleType: "06b6a3b998184b508925",
                age: 528402128
            ));

            await _personRepository.InsertAsync(new Person
            (
                id: Guid.Parse("cd3946e7-f748-4987-949f-6bfa26d44024"),
                personId: Guid.Parse("73e12316-254a-492f-94f7-28c5dd4cbed1"),
                name: "95b40b3a32dd485",
                surname: "e982837e47414bed8a1bf865e1bec20cb7afebfc2c28489d958c2a3d0c66e47ab1",
                contactNumber: "f7aff854f5c84a72b7c8d2c1eb",
                vehicleRegistration: "71f9221b207c4b409bf6884ba1895d6f94df58b47d9d44bf",
                vehicleType: "baea7e6a2be449c0876bdbb92c83f9ca6a66e7f2688d4496b9ff8399fdbe67f1615b1ce90d2d4f75b6cdf810dddd25",
                age: 496483297
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}