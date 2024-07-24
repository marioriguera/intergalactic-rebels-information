using System.ComponentModel.DataAnnotations;

namespace ConfigsApplication.HomeView.Common.DTOs;

/// <summary>
/// Represents the base configuration for a home slider.
/// </summary>
/// <param name="Src">The source URL of the slider image.</param>
/// <param name="Alt">The alt text for the slider image.</param>
public record HomeSliderConfigBase([Required] string Src, [Required] string Alt);