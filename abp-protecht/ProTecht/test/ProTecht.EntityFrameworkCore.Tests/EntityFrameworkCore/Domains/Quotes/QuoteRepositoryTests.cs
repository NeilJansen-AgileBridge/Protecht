using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using ProTecht.Quotes;
using ProTecht.EntityFrameworkCore;
using Xunit;

namespace ProTecht.EntityFrameworkCore.Domains.Quotes
{
    public class QuoteRepositoryTests : ProTechtEntityFrameworkCoreTestBase
    {
        private readonly IQuoteRepository _quoteRepository;

        public QuoteRepositoryTests()
        {
            _quoteRepository = GetRequiredService<IQuoteRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _quoteRepository.GetListAsync(
                    amount: "253105ff68b044b7844a51ea6ae1b1f7bc887",
                    vendor: default
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("1e1ca471-24fe-4849-aaf1-cc24148c309c"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _quoteRepository.GetCountAsync(
                    amount: "37d17aeebc3e40378be2da95a400f24c44b49b8a75e64d8390ea903797fa343e8dcf22c45a2a46f7b00cb5dec4a32",
                    vendor: default
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}