using ConfigsApplication.Abstracts;
using ConfigsApplication.HomeView.Common;

namespace ConfigsApplication.HomeView.GetAll;

public class GetAllHomeSliderQueryHandler : IQueryHandler<GetAllHomeSliderQuery, IReadOnlyList<HomeSlideConfigResponse>>
{
    public async Task<ErrorOr<IReadOnlyList<HomeSlideConfigResponse>>> Handle(GetAllHomeSliderQuery request, CancellationToken cancellationToken)
    {
        var list = new List<HomeSlideConfigResponse>()
        {
            new HomeSlideConfigResponse(id: Guid.NewGuid(), src: "newsrc1", alt: "newalt1"),
            new HomeSlideConfigResponse(id: Guid.NewGuid(), src: "newsrc2", alt: "newalt2"),
            new HomeSlideConfigResponse(id: Guid.NewGuid(), src: "newsrc3", alt: "newalt3"),
        };

        return list;
    }
}
