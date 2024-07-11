using System.ComponentModel.DataAnnotations;

namespace ConfigsApplication.HomeView.Common;

public record HomeSlideConfigRequest([Required] string src, [Required] string alt)
    : HomeSlideConfigBase(src, alt)
{ }
