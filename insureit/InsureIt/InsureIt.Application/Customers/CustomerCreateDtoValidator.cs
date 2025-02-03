using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.FluentValidation.Dtos.DTOValidator", Version = "2.0")]

namespace InsureIt.Application.Customers
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public class CustomerCreateDtoValidator : AbstractValidator<CustomerCreateDto>
    {
        [IntentManaged(Mode.Merge)]
        public CustomerCreateDtoValidator()
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