using System.ComponentModel.DataAnnotations;

namespace ConfigsApplication.HomeView.Common;

public record HomeSlideConfigBase([Required] string src, [Required] string alt);
