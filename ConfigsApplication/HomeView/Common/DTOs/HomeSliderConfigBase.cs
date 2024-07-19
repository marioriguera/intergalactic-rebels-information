using System.ComponentModel.DataAnnotations;

namespace ConfigsApplication.HomeView.Common.DTOs;

public record HomeSliderConfigBase([Required] string src, [Required] string alt);
