using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTecht.Shared.RequestDTOs
{
    public class VehicoverQuoteRequestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age {  get; set; }
        public string VehicleType {  get; set; } 
        public string VehicleRegistration {  get; set; } 
        public string ContactNumber {  get; set; } 
    }
}
