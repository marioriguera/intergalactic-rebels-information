using AutoMapper;
using ConfigsApplication.HomeView.Common.DTOs;
using ConfigsDomain.Entities;

namespace ConfigsApplication.HomeView.Common.Mappings;

internal sealed class HomeSliderMappingProfile : Profile
{
    public HomeSliderMappingProfile()
    {
        CreateMap<HomeViewSlider, HomeSliderConfigResponse>();
    }
}
