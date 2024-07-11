using System.ComponentModel.DataAnnotations;

namespace ConfigsApplication.HomeView.Common;

public record HomeSlideConfigResponse([Required] Guid id, [Required] string src, [Required] string alt)
    : HomeSlideConfigBase(src, alt)
{
}
