using ProTecht.People;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using ProTecht.Quotes;

namespace ProTecht.Quotes
{
    public class QuotesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IQuoteRepository _quoteRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly PeopleDataSeedContributor _peopleDataSeedContributor;

        public QuotesDataSeedContributor(IQuoteRepository quoteRepository, IUnitOfWorkManager unitOfWorkManager, PeopleDataSeedContributor peopleDataSeedContributor)
        {
            _quoteRepository = quoteRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _peopleDataSeedContributor = peopleDataSeedContributor;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _peopleDataSeedContributor.SeedAsync(context);

            await _quoteRepository.InsertAsync(new Quote
            (
                id: Guid.Parse("1e1ca471-24fe-4849-aaf1-cc24148c309c"),
                amount: "253105ff68b044b7844a51ea6ae1b1f7bc887",
                vendor: default,
                personId: null
            ));

            await _quoteRepository.InsertAsync(new Quote
            (
                id: Guid.Parse("74dbb504-f39e-4189-a893-afceb1c32e46"),
                amount: "37d17aeebc3e40378be2da95a400f24c44b49b8a75e64d8390ea903797fa343e8dcf22c45a2a46f7b00cb5dec4a32",
                vendor: default,
                personId: null
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}