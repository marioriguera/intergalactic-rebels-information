using System.ComponentModel.DataAnnotations;

namespace ConfigsApplication.HomeView.Common.DTOs;

/// <summary>
/// Represents the response model for home slider configurations.
/// </summary>
/// <param name="Id">The unique identifier for the home slider configuration.</param>
/// <param name="Src">The source URL of the slider image.</param>
/// <param name="Alt">The alt text for the slider image.</param>
public record HomeSliderConfigResponse([Required] Guid Id, [Required] string Src, [Required] string Alt)
    : HomeSliderConfigBase(Src, Alt)
{
}