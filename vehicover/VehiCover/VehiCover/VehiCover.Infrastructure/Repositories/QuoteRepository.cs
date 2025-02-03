using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using VehiCover.Domain.Entities;
using VehiCover.Domain.Repositories;
using VehiCover.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace VehiCover.Infrastructure.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class QuoteRepository : RepositoryBase<Quote, Quote, ApplicationDbContext>, IQuoteRepository
    {
        public QuoteRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<TProjection?> FindByIdProjectToAsync<TProjection>(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await FindProjectToAsync<TProjection>(x => x.Id == id, cancellationToken);
        }

        public async Task<Quote?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<Quote>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => ids.Contains(x.Id), cancellationToken);
        }
    }
}