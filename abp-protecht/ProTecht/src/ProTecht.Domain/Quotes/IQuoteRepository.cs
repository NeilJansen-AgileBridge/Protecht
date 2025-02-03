using ProTecht.Enum;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ProTecht.Quotes
{
    public partial interface IQuoteRepository : IRepository<Quote, Guid>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? amount = null,
            Vendor? vendor = null,
            Guid? personId = null,
            CancellationToken cancellationToken = default);
        Task<QuoteWithNavigationProperties> GetWithNavigationPropertiesAsync(
            Guid id,
            CancellationToken cancellationToken = default
        );

        Task<List<QuoteWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? amount = null,
            Vendor? vendor = null,
            Guid? personId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<Quote>> GetListAsync(
                    string? filterText = null,
                    string? amount = null,
                    Vendor? vendor = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? amount = null,
            Vendor? vendor = null,
            Guid? personId = null,
            CancellationToken cancellationToken = default);
    }
}