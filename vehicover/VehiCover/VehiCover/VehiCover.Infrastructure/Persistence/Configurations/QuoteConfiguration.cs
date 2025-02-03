using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehiCover.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace VehiCover.Infrastructure.Persistence.Configurations
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount)
                .IsRequired();

            builder.Property(x => x.ClientId)
                .IsRequired();

            builder.Property(x => x.Date)
                .IsRequired();

            builder.Ignore(e => e.DomainEvents);
        }
    }
}