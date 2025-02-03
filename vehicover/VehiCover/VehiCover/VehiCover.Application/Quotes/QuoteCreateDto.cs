using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace VehiCover.Application.Quotes
{
    public class QuoteCreateDto
    {
        public QuoteCreateDto()
        {
            PersonId = Guid.NewGuid();
            Age = 0;
            Name = null!;
            Surname = null!;
            ContactNumber = null!;
            VehicleRegistration = null!;
            VehicleType = null!;
        }

        public Guid PersonId { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactNumber { get; set; }
        public string VehicleRegistration { get; set; }
        public string VehicleType { get; set; }


        public static QuoteCreateDto Create(Guid personId, int age, string name, string surname, string contactNumber, string vehicleRegistration, string vehicleType)
        {
            return new QuoteCreateDto
            {
                //Amount = amount,
                PersonId = personId,
                Age = age, 
                Name = name,
                Surname = surname,
                ContactNumber = contactNumber,
                VehicleRegistration = vehicleRegistration,
                VehicleType = vehicleType
            };
        }
    }
}