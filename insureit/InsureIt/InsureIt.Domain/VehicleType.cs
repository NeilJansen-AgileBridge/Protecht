using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEnum", Version = "1.0")]

namespace InsureIt.Domain
{
    public enum VehicleType
    {
        Hatchback,
        Bakkie,
        Sedan,
        Suv,
        Convertible,
        Coupe,
        Minibus,
        Stationwagon
    }
}