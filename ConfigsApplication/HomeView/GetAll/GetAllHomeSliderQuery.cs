using ConfigsApplication.Abstracts;
using ConfigsApplication.HomeView.Common;

namespace ConfigsApplication.HomeView.GetAll;

/// <summary>
/// Represents a query to get all home slider configurations.
/// </summary>
public sealed record GetAllHomeSliderQuery()
    : IQuery<IReadOnlyList<HomeSlideConfigResponse>>
{
}