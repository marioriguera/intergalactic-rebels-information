using ConfigsApplication.Abstracts;
using ConfigsApplication.HomeView.Common.DTOs;

namespace ConfigsApplication.HomeView.GetAll;

public class GetAllHomeSliderQueryHandler : IQueryHandler<GetAllHomeSliderQuery, IReadOnlyList<HomeSliderConfigResponse>>
{
    public async Task<ErrorOr<IReadOnlyList<HomeSliderConfigResponse>>> Handle(GetAllHomeSliderQuery request, CancellationToken cancellationToken)
    {
        var list = new List<HomeSliderConfigResponse>()
        {
            new HomeSliderConfigResponse(id: Guid.NewGuid(), src: "newsrc1", alt: "newalt1"),
            new HomeSliderConfigResponse(id: Guid.NewGuid(), src: "newsrc2", alt: "newalt2"),
            new HomeSliderConfigResponse(id: Guid.NewGuid(), src: "newsrc3", alt: "newalt3"),
        };

        return list;
    }
}
