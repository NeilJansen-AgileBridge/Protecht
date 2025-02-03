using ProTecht.Quotes;
using System;
using ProTecht.Shared;
using Volo.Abp.AutoMapper;
using ProTecht.People;
using AutoMapper;

namespace ProTecht;

public class ProTechtApplicationAutoMapperProfile : Profile
{
    public ProTechtApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Person, PersonDto>();
        CreateMap<Person, PersonExcelDto>();

        CreateMap<Quote, QuoteDto>();
        CreateMap<Quote, QuoteExcelDto>();

        CreateMap<QuoteWithNavigationProperties, QuoteWithNavigationPropertiesDto>();
        CreateMap<Person, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));
    }
}