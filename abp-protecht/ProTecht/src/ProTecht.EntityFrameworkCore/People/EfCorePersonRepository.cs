using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using ProTecht.EntityFrameworkCore;

namespace ProTecht.People
{
    public abstract class EfCorePersonRepositoryBase : EfCoreRepository<ProTechtDbContext, Person, Guid>
    {
        public EfCorePersonRepositoryBase(IDbContextProvider<ProTechtDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        Guid? personId = null,
            string? name = null,
            string? surname = null,
            string? contactNumber = null,
            string? vehicleRegistration = null,
            string? vehicleType = null,
            int? ageMin = null,
            int? ageMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, personId, name, surname, contactNumber, vehicleRegistration, vehicleType, ageMin, ageMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Person>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, personId, name, surname, contactNumber, vehicleRegistration, vehicleType, ageMin, ageMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PersonConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            Guid? personId = null,
            string? name = null,
            string? surname = null,
            string? contactNumber = null,
            string? vehicleRegistration = null,
            string? vehicleType = null,
            int? ageMin = null,
            int? ageMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, personId, name, surname, contactNumber, vehicleRegistration, vehicleType, ageMin, ageMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Person> ApplyFilter(
            IQueryable<Person> query,
            string? filterText = null,
            Guid? personId = null,
            string? name = null,
            string? surname = null,
            string? contactNumber = null,
            string? vehicleRegistration = null,
            string? vehicleType = null,
            int? ageMin = null,
            int? ageMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name!.Contains(filterText!) || e.Surname!.Contains(filterText!) || e.ContactNumber!.Contains(filterText!) || e.VehicleRegistration!.Contains(filterText!) || e.VehicleType!.Contains(filterText!))
                    .WhereIf(personId.HasValue, e => e.PersonId == personId)
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(surname), e => e.Surname.Contains(surname))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactNumber), e => e.ContactNumber.Contains(contactNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(vehicleRegistration), e => e.VehicleRegistration.Contains(vehicleRegistration))
                    .WhereIf(!string.IsNullOrWhiteSpace(vehicleType), e => e.VehicleType.Contains(vehicleType))
                    .WhereIf(ageMin.HasValue, e => e.Age >= ageMin!.Value)
                    .WhereIf(ageMax.HasValue, e => e.Age <= ageMax!.Value);
        }
    }
}