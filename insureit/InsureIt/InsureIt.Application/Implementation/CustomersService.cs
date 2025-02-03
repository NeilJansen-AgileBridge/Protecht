using System.Text.Json;
using System.Web.Http;
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

       


        public async Task<int> GetQuote([FromBody] MyPerson person, CancellationToken cancellationToken = default)
        {

            //MyPerson customerObj = new MyPerson
            //{
            //    surname = customer.surname,
            //    name = customer.name,
            //    id = customer.id,
            //    contactNumber = customer.contactNumber,
            //    vehicleReg = customer.vehicleReg,
            //    vehicleType = customer.vehicleType,
            //    age = customer.age,
            //};


            try
            {
                if (FindCustomerById(person.id) != null)
                {
                    Random amount = new Random();
                    int init = amount.Next(1000, 5000);
                    return await Task.FromResult(init);
                }
                else
                {

                    var customerDto = new CustomerCreateDto
                    {
                        Name = person.name,  
                        Age = person.age,  
                        PhoneNumber = person.contactNumber 
                    };

                    await CreateCustomer(customerDto, cancellationToken);

                    Random amount = new Random();
                    int init = amount.Next(1000, 5000);
                    return await Task.FromResult(init);
                }

            }
            catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }

            
        }
    }
    public class MyPerson
    {
        public string surname { get; set; }
        public string name { get; set; }
        public Guid id { get; set; }
        public string contactNumber { get; set; }
        public string vehicleReg { get; set; }
        public string vehicleType { get; set; }
        public int age { get; set; }
    }
}