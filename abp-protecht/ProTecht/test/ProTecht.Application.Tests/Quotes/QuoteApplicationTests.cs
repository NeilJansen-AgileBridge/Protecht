using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace ProTecht.Quotes
{
    public abstract class QuotesAppServiceTests<TStartupModule> : ProTechtApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IQuotesAppService _quotesAppService;
        private readonly IRepository<Quote, Guid> _quoteRepository;

        public QuotesAppServiceTests()
        {
            _quotesAppService = GetRequiredService<IQuotesAppService>();
            _quoteRepository = GetRequiredService<IRepository<Quote, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _quotesAppService.GetListAsync(new GetQuotesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Quote.Id == Guid.Parse("1e1ca471-24fe-4849-aaf1-cc24148c309c")).ShouldBe(true);
            result.Items.Any(x => x.Quote.Id == Guid.Parse("74dbb504-f39e-4189-a893-afceb1c32e46")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _quotesAppService.GetAsync(Guid.Parse("1e1ca471-24fe-4849-aaf1-cc24148c309c"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("1e1ca471-24fe-4849-aaf1-cc24148c309c"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new QuoteCreateDto
            {
                Amount = "b75e873c4a1a4fec83e40c4a54b63305745310a54e4049ffa1677719e860398e966f0bb58b6a416eae586b290c1169d24",
                Vendor = default
            };

            // Act
            var serviceResult = await _quotesAppService.CreateAsync(input);

            // Assert
            var result = await _quoteRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Amount.ShouldBe("b75e873c4a1a4fec83e40c4a54b63305745310a54e4049ffa1677719e860398e966f0bb58b6a416eae586b290c1169d24");
            result.Vendor.ShouldBe(default);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new QuoteUpdateDto()
            {
                Amount = "c4adb1f319284d68aca1",
                Vendor = default
            };

            // Act
            var serviceResult = await _quotesAppService.UpdateAsync(Guid.Parse("1e1ca471-24fe-4849-aaf1-cc24148c309c"), input);

            // Assert
            var result = await _quoteRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Amount.ShouldBe("c4adb1f319284d68aca1");
            result.Vendor.ShouldBe(default);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _quotesAppService.DeleteAsync(Guid.Parse("1e1ca471-24fe-4849-aaf1-cc24148c309c"));

            // Assert
            var result = await _quoteRepository.FindAsync(c => c.Id == Guid.Parse("1e1ca471-24fe-4849-aaf1-cc24148c309c"));

            result.ShouldBeNull();
        }
    }
}