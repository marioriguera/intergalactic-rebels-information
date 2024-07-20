using System.ComponentModel.DataAnnotations;

namespace ConfigsApplication.HomeView.Common.DTOs;

public record HomeSliderConfigRequest([Required] string src, [Required] string alt)
    : HomeSliderConfigBase(src, alt)
{ }
