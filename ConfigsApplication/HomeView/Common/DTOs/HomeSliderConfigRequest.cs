using System.ComponentModel.DataAnnotations;

namespace ConfigsApplication.HomeView.Common.DTOs;

/// <summary>
/// Represents the request model for home slider configurations.
/// </summary>
/// <param name="Src">The source URL of the slider image.</param>
/// <param name="Alt">The alt text for the slider image.</param>
public record HomeSliderConfigRequest([Required] string Src, [Required] string Alt)
    : HomeSliderConfigBase(Src, Alt)
{ }