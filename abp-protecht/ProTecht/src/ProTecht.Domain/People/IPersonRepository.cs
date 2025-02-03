using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ProTecht.People
{
    public partial interface IPersonRepository : IRepository<Person, Guid>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            Guid? personId = null,
            string? name = null,
            string? surname = null,
            string? contactNumber = null,
            string? vehicleRegistration = null,
            string? vehicleType = null,
            int? ageMin = null,
            int? ageMax = null,
            CancellationToken cancellationToken = default);
        Task<List<Person>> GetListAsync(
                    string? filterText = null,
                    Guid? personId = null,
                    string? name = null,
                    string? surname = null,
                    string? contactNumber = null,
                    string? vehicleRegistration = null,
                    string? vehicleType = null,
                    int? ageMin = null,
                    int? ageMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            Guid? personId = null,
            string? name = null,
            string? surname = null,
            string? contactNumber = null,
            string? vehicleRegistration = null,
            string? vehicleType = null,
            int? ageMin = null,
            int? ageMax = null,
            CancellationToken cancellationToken = default);
    }
}