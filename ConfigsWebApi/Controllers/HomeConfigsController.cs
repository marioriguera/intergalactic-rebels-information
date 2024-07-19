using ConfigsApplication.HomeView.Common.DTOs;
using ConfigsApplication.HomeView.GetAll;

namespace ConfigsWebApi.Controllers;

[Route("home-view-configs")]
public class HomeConfigsController : ApiController
{
    public HomeConfigsController(ISender mediator)
        : base(mediator)
    {
    }

    [HttpGet]
    [Route("all-configs")]
    public async Task<IActionResult> Index()
    {
        return Ok();
    }

    [HttpGet]
    [Route("by-id:{id}")]
    public async Task<IActionResult> Details(int id)
    {
        return Ok();
    }

    [HttpGet]
    [Route("all-slide-home-configs")]
    public async Task<IActionResult> GetAllHomeSlideConfigurations()
    {
        var allSlidesConfigs = await _mediator.Send(new GetAllHomeSliderQuery());
        return allSlidesConfigs.Match(
                configs => Ok(configs),
                errors => Problem(errors));
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] IFormCollection collection)
    {
        try
        {
            return Ok(nameof(Index));
        }
        catch
        {
            return Ok();
        }
    }

    [HttpPut]
    [Route("edit-slide-config:{id}")]
    public async Task<IActionResult> EditOneConfig(int id, [FromBody] HomeSliderConfigRequest configRequest)
    {
        return Ok();
    }

    [HttpPatch]
    [Route("edit-slide-src-config:{id}")]
    public async Task<IActionResult> EditSlideSourceConfig(int id, string src)
    {
        return Ok();
    }


    [HttpPatch]
    [Route("edit-slide-alt-config:{id}")]
    public async Task<IActionResult> EditSlideAltConfig(int id, string alt)
    {
        return Ok();
    }

    [HttpPut]
    [Route("edit-all-slides-configs")]
    public async Task<IActionResult> EditAllSlidesConfigs([FromBody] IFormCollection collection)
    {
        try
        {
            return Ok(nameof(Index));
        }
        catch
        {
            return Ok();
        }
    }

    [HttpDelete]
    [Route("delete-by-id:{id}")]
    public async Task<IActionResult> DeleteConfigById(int id)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("delete-all-configs")]
    public async Task<IActionResult> DeleteAllConfigs()
    {
        try
        {
            return Ok(nameof(Index));
        }
        catch
        {
            return Ok();
        }
    }
}
