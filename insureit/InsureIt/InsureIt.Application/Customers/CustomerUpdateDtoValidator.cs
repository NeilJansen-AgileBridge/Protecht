using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.FluentValidation.Dtos.DTOValidator", Version = "2.0")]

namespace InsureIt.Application.Customers
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public class CustomerUpdateDtoValidator : AbstractValidator<CustomerUpdateDto>
    {
        [IntentManaged(Mode.Merge)]
        public CustomerUpdateDtoValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Name)
                .NotNull();

            RuleFor(v => v.PhoneNumber)
                .NotNull();
        }
    }
}