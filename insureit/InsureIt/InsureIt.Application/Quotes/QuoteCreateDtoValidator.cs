using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.FluentValidation.Dtos.DTOValidator", Version = "2.0")]

namespace InsureIt.Application.Quotes
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
            RuleFor(v => v.VehicleType)
                .NotNull()
                .IsInEnum();

            RuleFor(v => v.VehicleReg)
                .NotNull();
        }
    }
}