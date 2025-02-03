using InsureIt.Application.Customers;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.ServiceContract", Version = "1.0")]

namespace InsureIt.Application.Interfaces
{
    public interface ICustomersService
    {
        Task<Guid> CreateCustomer(CustomerCreateDto dto, CancellationToken cancellationToken = default);
        Task<CustomerDto> FindCustomerById(Guid id, CancellationToken cancellationToken = default);
        Task<List<CustomerDto>> FindCustomers(CancellationToken cancellationToken = default);
        Task UpdateCustomer(Guid id, CustomerUpdateDto dto, CancellationToken cancellationToken = default);
        Task DeleteCustomer(Guid id, CancellationToken cancellationToken = default);
        Task<int> GetQuote(object person, CancellationToken cancellationToken = default);
    }
}