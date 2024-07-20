using System.ComponentModel.DataAnnotations;

namespace ConfigsApplication.HomeView.Common.DTOs;

public record HomeSliderConfigResponse([Required] Guid id, [Required] string src, [Required] string alt)
    : HomeSliderConfigBase(src, alt)
{
}
