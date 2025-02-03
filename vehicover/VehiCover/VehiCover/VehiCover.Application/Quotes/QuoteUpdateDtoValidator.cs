using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.FluentValidation.Dtos.DTOValidator", Version = "2.0")]

namespace VehiCover.Application.Quotes
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public class QuoteUpdateDtoValidator : AbstractValidator<QuoteUpdateDto>
    {
        [IntentManaged(Mode.Merge)]
        public QuoteUpdateDtoValidator()
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