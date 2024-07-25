using AutoMapper;
using ConfigsApplication.Abstracts;
using ConfigsApplication.HomeView.Common.DTOs;
using ConfigsDomain.Repositories;

namespace ConfigsApplication.HomeView.GetAll;

/// <summary>
/// Handles queries to retrieve all home slider configurations.
/// </summary>
internal sealed class GetAllHomeSliderQueryHandler
    : IQueryHandler<GetAllHomeSliderQuery, IReadOnlyList<HomeSliderConfigResponse>>
{
    private readonly IHomeViewRepository _homeViewRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllHomeSliderQueryHandler"/> class.
    /// </summary>
    /// <param name="homeViewRepository">The repository to access home view data.</param>
    /// <param name="mapper">The mapper to convert data models to response models.</param>
    public GetAllHomeSliderQueryHandler(IHomeViewRepository homeViewRepository, IMapper mapper)
    {
        _homeViewRepository = homeViewRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the specified request to retrieve all home slider configurations.
    /// </summary>
    /// <param name="request">The request to get all home slider configurations.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a list of <see cref="HomeSliderConfigResponse"/> wrapped in an <see cref="ErrorOr{T}"/>.
    /// </returns>
    public async Task<ErrorOr<IReadOnlyList<HomeSliderConfigResponse>>> Handle(GetAllHomeSliderQuery request, CancellationToken cancellationToken)
        => await Task.Run(() => _homeViewRepository.GetAllHomeViewSlidersConfigurations(cancellationToken)
                                                   .Select(x => _mapper.Map<HomeSliderConfigResponse>(x))
                                                   .ToList());
}