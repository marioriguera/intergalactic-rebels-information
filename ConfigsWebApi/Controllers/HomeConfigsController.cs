using ConfigsWebApi.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace ConfigsWebApi.Controllers;

[ApiController]
[Route("home-configurations")]
public class HomeConfigsController : ControllerBase
{
    [HttpGet]
    [Route("all-configurations")]
    public IActionResult Index()
    {
        return Ok();
    }

    [HttpGet]
    [Route("by-id:{id}")]
    public IActionResult Details(int id)
    {
        return Ok();
    }

    [HttpPost]
    [Route("create-default")]
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpPost]
    [Route("create")]
    public IActionResult Create([FromBody] IFormCollection collection)
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
    public IActionResult EditOneConfig(int id, [FromBody] HomeSlideConfigRequest configRequest)
    {
        return Ok();
    }

    [HttpPatch]
    [Route("edit-slide-src-config:{id}")]
    public IActionResult EditSlideSourceConfig(int id, string src)
    {
        return Ok();
    }


    [HttpPatch]
    [Route("edit-slide-alt-config:{id}")]
    public IActionResult EditSlideAltConfig(int id, string alt)
    {
        return Ok();
    }

    [HttpPut]
    [Route("edit-all-slides-configs")]
    public IActionResult EditAllSlidesConfigs([FromBody] IFormCollection collection)
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
    public IActionResult DeleteConfigById(int id)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("delete-all-configs")]
    public IActionResult DeleteAllConfigs()
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
