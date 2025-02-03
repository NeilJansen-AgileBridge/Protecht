using Volo.Abp.Application.Dtos;
using System;

namespace ProTecht.People
{
    public abstract class GetPeopleInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public Guid? PersonId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? ContactNumber { get; set; }
        public string? VehicleRegistration { get; set; }
        public string? VehicleType { get; set; }
        public int? AgeMin { get; set; }
        public int? AgeMax { get; set; }

        public GetPeopleInputBase()
        {

        }
    }
}