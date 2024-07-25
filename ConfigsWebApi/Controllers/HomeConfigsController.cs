using ConfigsApplication.HomeView.GetAll;

namespace ConfigsWebApi.Controllers;

/// <summary>
/// Controller for managing home view configurations.
/// </summary>
[Route("home-view-configs")]
public class HomeConfigsController : ApiController
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HomeConfigsController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator to handle queries and commands.</param>
    public HomeConfigsController(ISender mediator)
        : base(mediator)
    {
    }

    /// <summary>
    /// Gets all home slide configurations.
    /// </summary>
    /// <returns>
    /// An <see cref="IActionResult"/> representing the result of the operation.
    /// Returns a 200 OK response with the list of configurations if successful,
    /// or a 500 Problem response if there are errors.
    /// </returns>
    /// <remarks>
    /// Example response:
    ///
    /// ```json
    ///  [
    ///    {
    ///        "id": "e7bc13e9-0e2a-4ad1-83ae-1130c3862b3c",
    ///        "src": "https://wallpapersmug.com/download/3840x2160/d06c64/starry-space-milky-way-stars.jpg",
    ///        "alt": "Wallpaper start"
    ///    },
    ///    {
    ///        "id": "c4438db0-7b74-4f66-b37b-7259b1273c4a",
    ///        "src": "https://wallpapers.com/images/hd/4k-space-glowing-ring-es4tss2e6i1dzfj6.jpg",
    ///        "alt": "Glowing ring"
    ///    },
    ///    {
    ///        "id": "9444b29d-f459-4ff2-bfc6-dacea6543288",
    ///        "src": "https://wallpapers.com/images/hd/4k-universe-eta-carinae-nebula-2iqpijwfzmw3z4al.jpg",
    ///        "alt": "Universe nebulosa"
    ///    }
    ///  ]
    /// ```
    /// </remarks>
    [HttpGet]
    [Route("all-slide-home-configs")]
    public async Task<IActionResult> GetAllHomeSlideConfigurations()
    {
        var allSlidesConfigs = await Mediator.Send(new GetAllHomeSliderQuery());
        return allSlidesConfigs.Match(
                configs => Ok(configs),
                errors => Problem(errors));
    }
}