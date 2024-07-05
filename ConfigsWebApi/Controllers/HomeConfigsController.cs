using Microsoft.AspNetCore.Mvc;

namespace ConfigsWebApi.Controllers
{
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

        [HttpPatch]
        [Route("edit-slide-config:{id}")]
        public IActionResult EditOneConfig(int id/* ToDo: , [FromBody] data to edit*/)
        {
            return Ok();
        }

        // POST: HomeConfigsController/Edit/5
        [HttpPut]
        [Route("edit-all-slides-configs")]
        public IActionResult EditAllSlidesConfigs([FromBody]IFormCollection collection)
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

        // POST: HomeConfigsController/Delete/5
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
}
