using AutoMapper;
using ConfigsApplication.Abstracts;
using ConfigsApplication.HomeView.Common.DTOs;
using ConfigsDomain.Repositories;

namespace ConfigsApplication.HomeView.GetAll;

internal sealed class GetAllHomeSliderQueryHandler : IQueryHandler<GetAllHomeSliderQuery, IReadOnlyList<HomeSliderConfigResponse>>
{
    private readonly IHomeViewRepository _homeViewRepository;
    private readonly IMapper _mapper;

    public GetAllHomeSliderQueryHandler(IHomeViewRepository homeViewRepository, IMapper mapper)
    {
        _homeViewRepository = homeViewRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<IReadOnlyList<HomeSliderConfigResponse>>> Handle(GetAllHomeSliderQuery request, CancellationToken cancellationToken)
    {
        var result = await _homeViewRepository.GetAllHomeViewSlidersConfigurationsAsync(cancellationToken);

        return result.Select(x => _mapper.Map<HomeSliderConfigResponse>(x)).ToList();
    }
}
