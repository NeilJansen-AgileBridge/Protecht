using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.FluentValidation.Dtos.DTOValidator", Version = "2.0")]

namespace VehiCover.Application.Quotes
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public class QuoteCreateDtoValidator : AbstractValidator<QuoteCreateDto>
    {
        [IntentManaged(Mode.Merge)]
        public QuoteCreateDtoValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ClientId)
                .NotNull();

            RuleFor(v => v.Date)
                .NotNull();
        }
    }
}