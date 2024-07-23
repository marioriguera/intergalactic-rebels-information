using AutoMapper;
using ConfigsApplication.HomeView.Common.DTOs;
using ConfigsDomain.Entities;

namespace ConfigsApplication.HomeView.Common.Mappings;

/// <summary>
/// Mapping profile for HomeSlider entities and DTOs.
/// </summary>
internal sealed class HomeSliderMappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HomeSliderMappingProfile"/> class.
    /// </summary>
    public HomeSliderMappingProfile()
    {
        /// <summary>
        /// Configures the mapping between <see cref="HomeViewSlider"/> and <see cref="HomeSliderConfigResponse"/>.
        /// </summary>
        CreateMap<HomeViewSlider, HomeSliderConfigResponse>();
    }
}