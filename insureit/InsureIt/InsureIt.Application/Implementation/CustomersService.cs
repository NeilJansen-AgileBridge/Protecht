using AutoMapper;
using InsureIt.Application.Customers;
using InsureIt.Application.Interfaces;
using InsureIt.Domain.Common.Exceptions;
using InsureIt.Domain.Entities;
using InsureIt.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.ServiceImplementations.ServiceImplementation", Version = "1.0")]

namespace InsureIt.Application.Implementation
{
    [IntentManaged(Mode.Merge)]
    public class CustomersService : ICustomersService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Merge)]
        public CustomersService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Guid> CreateCustomer(CustomerCreateDto dto, CancellationToken cancellationToken = default)
        {
            var customer = new Customer
            {
                Name = dto.Name,
                Age = dto.Age,
                PhoneNumber = dto.PhoneNumber
            };

            _customerRepository.Add(customer);
            await _customerRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return customer.Id;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<CustomerDto> FindCustomerById(Guid id, CancellationToken cancellationToken = default)
        {
            var customer = await _customerRepository.FindByIdAsync(id, cancellationToken);
            if (customer is null)
            {
                throw new NotFoundException($"Could not find Customer '{id}'");
            }
            return customer.MapToCustomerDto(_mapper);
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<CustomerDto>> FindCustomers(CancellationToken cancellationToken = default)
        {
            var customers = await _customerRepository.FindAllAsync(cancellationToken);
            return customers.MapToCustomerDtoList(_mapper);
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task UpdateCustomer(Guid id, CustomerUpdateDto dto, CancellationToken cancellationToken = default)
        {
            var customer = await _customerRepository.FindByIdAsync(id, cancellationToken);
            if (customer is null)
            {
                throw new NotFoundException($"Could not find Customer '{id}'");
            }

            customer.Name = dto.Name;
            customer.Age = dto.Age;
            customer.PhoneNumber = dto.PhoneNumber;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task DeleteCustomer(Guid id, CancellationToken cancellationToken = default)
        {
            var customer = await _customerRepository.FindByIdAsync(id, cancellationToken);
            if (customer is null)
            {
                throw new NotFoundException($"Could not find Customer '{id}'");
            }

            _customerRepository.Remove(customer);
        }

        public class person
        {
            string surname { get; set; }
            string name { get; set; }
            Guid id { get; set; }
            string contactNumber { get; set; }
            string vehicleReg { get; set; }
            string vehicleType { get; set; }
            int age { get; set; }
        }


        public async Task<int> GetQuote(object person, CancellationToken cancellationToken = default)
        {
            Random amount = new Random();
            int init = amount.Next(1000, 5000);
            return await Task.FromResult(init);
        }
    }
}