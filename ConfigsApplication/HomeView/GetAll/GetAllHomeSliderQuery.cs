using ConfigsApplication.Abstracts;
using ConfigsApplication.HomeView.Common;

namespace ConfigsApplication.HomeView.GetAll;

public sealed record GetAllHomeSliderQuery()
    : IQuery<IReadOnlyList<HomeSlideConfigResponse>>
{
}
